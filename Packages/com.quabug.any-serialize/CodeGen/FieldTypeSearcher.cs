using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    public class FieldTypeSearcher : ITypeSearcher<AnyFieldTypeAttribute>
    {
        private readonly TypeReference? _fieldType;

        public FieldTypeSearcher(
            ILPostProcessorLogger logger,
            [Inject(typeof(AttributeLabel<>))] string fieldDeclaringTypeParameterName,
            [Inject(typeof(GenericLabel<>))] GenericInstanceType genericType,
            [Inject(typeof(GenericLabel<>))] GenericParameter parameter
        )
        {
            var fieldIndex = -1;
            var searcherFieldCount = 0;
            var genericTypeDefinition = genericType.Resolve()!;
            foreach (var genericParameter in genericTypeDefinition.GenericParameters!)
            {
                if (genericParameter.Name == parameter.Name)
                    fieldIndex = searcherFieldCount;
                
                if (genericParameter.GetAttributesOf<AnyFieldTypeAttribute>().Any())
                    searcherFieldCount++;
            }

            var declaringGenericIndex = genericTypeDefinition.GenericParameters.FindIndexOf(parameter => parameter.Name == fieldDeclaringTypeParameterName);
            var declaringType = genericType.GenericArguments![declaringGenericIndex]!;
            var fields =  AnyClassUtility.Reorder(
                declaringType.Resolve()!.Fields.Where(field => !field.IsStatic),
                field => (int?)field.GetAttributesOf<AnySerializeFieldOrderAttribute>().SingleOrDefault()?.ConstructorArguments[0].Value
            ).ToArray();
            if (searcherFieldCount != fields.Length || fieldIndex < 0) return;

            var field = fields[fieldIndex];
            var property = field.GetBackingFieldProperty();
            var fieldType = property == null ? field.FieldType! : property.PropertyType!;

            _fieldType = !fieldType.IsConcreteType() && declaringType is GenericInstanceType genericInstanceType
                ? fieldType.FillGenericTypesByReferenceGenericName(genericInstanceType)
                : fieldType
            ;
            logger.Debug($"[{GetType()}] {genericType}: {parameter.Name} = {_fieldType}");
        }
        
        public TypeReference? Search()
        {
            return _fieldType;
        }
    }
}