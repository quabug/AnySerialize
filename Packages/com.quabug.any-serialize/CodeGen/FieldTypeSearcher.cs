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
            var fields = declaringType.Resolve().Fields.Where(field => !field.IsStatic).Select(field => field.FieldType).ToArray();
            if (declaringType is GenericInstanceType genericDeclaringType)
            {
                for (var i = 0; i < fields.Length; i++)
                {
                    if (!fields[i].IsConcreteType()) fields[i] = fields[i].FillGenericTypesByReferenceGenericName(genericDeclaringType);
                }
            }
            
            if (searcherFieldCount == fields.Length && fieldIndex >= 0) _fieldType = fields[fieldIndex];
        }
        
        public TypeReference Search()
        {
            return _fieldType;
        }
    }
}