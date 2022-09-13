using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    public class FieldTypeSearcher : ITypeSearcher<AnyFieldTypeAttribute>
    {
        private readonly TypeReference _fieldType;

        public FieldTypeSearcher(
            ILPostProcessorLogger logger,
            ModuleDefinition module,
            [Inject(typeof(AttributeLabel<>))] string fieldDeclaringTypeParameterName,
            [Inject(typeof(GenericLabel<>))] GenericInstanceType genericType,
            [Inject(typeof(GenericLabel<>))] GenericParameter parameter
        )
        {
            var fieldIndex = -1;
            var searcherFieldCount = 0;
            var genericTypeDefinition = genericType.Resolve();
            foreach (var genericParameter in genericTypeDefinition.GenericParameters)
            {
                if (genericParameter.Name == parameter.Name)
                    fieldIndex = searcherFieldCount;
                
                if (genericParameter.GetAttributesOf<AnyFieldTypeAttribute>().Any())
                    searcherFieldCount++;
            }

            var declaringGenericIndex = genericTypeDefinition.GenericParameters.FindIndexOf(parameter => parameter.Name == fieldDeclaringTypeParameterName);
            var declaringType = genericType.GenericArguments[declaringGenericIndex];
//             
// #if UNITY_2020
//             // HACK: cannot get fields from declaring type on Unity 2020
//             var reflectionFields = declaringType.Resolve().ToReflectionType().GetFields(AnyClassUtility.DefaultBindingFlags);
//             if (searcherFieldCount != reflectionFields.Length || fieldIndex < 0) return;
//             
//             var reflectionField = reflectionFields[fieldIndex];
//             
//             _fieldType = reflectionField.FieldType.IsGenericParameter
//                 ? new GenericParameter(reflectionField.FieldType.Name, declaringType)
//                 : module.ImportType(reflectionField.FieldType, logger)
//             ;
//             
//             if (!_fieldType.IsConcreteType() && declaringType is GenericInstanceType genericInstanceType)
//             {
//                 logger.Debug($"[{GetType()}] fill generic type {_fieldType} by {genericInstanceType}");
//                 _fieldType = _fieldType.FillGenericTypesByReferenceGenericName(genericInstanceType, logger);
//             }
// #else
            var fields =  declaringType.Resolve().Fields.Where(field => !field.IsStatic).Select(field => field.FieldType).ToArray();
            if (searcherFieldCount != fields.Length || fieldIndex < 0) return;

            _fieldType = !fields[fieldIndex].IsConcreteType() && declaringType is GenericInstanceType genericInstanceType
                ? fields[fieldIndex].FillGenericTypesByReferenceGenericName(genericInstanceType)
                : fields[fieldIndex]
            ;
// #endif
            logger.Debug($"[{GetType()}] {genericType}: {parameter.Name} = {_fieldType}");
        }
        
        public TypeReference Search()
        {
            return _fieldType;
        }
    }
}