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
            [Inject(typeof(OuterLabel<>))] TypeReference propertyType,
            [Inject(typeof(GenericLabel<>))] TypeReference genericType,
            [Inject(typeof(GenericLabel<>))] GenericParameter parameter
        )
        {
            var fieldIndex = -1;
            var searcherFieldCount = 0;
            foreach (var genericParameter in genericType.Resolve().GenericParameters)
            {
                if (genericParameter.Name == parameter.Name)
                    fieldIndex = searcherFieldCount;
                
                if (genericParameter.GetAttributesOf<AnyFieldTypeAttribute>().Any())
                    searcherFieldCount++;
            }
            
            var fields = propertyType.Resolve().Fields.Where(field => !field.IsStatic).Select(field => field.FieldType).ToArray();
            if (searcherFieldCount == fields.Length && fieldIndex >= 0) _fieldType = fields[fieldIndex];
        }
        
        public TypeReference Search()
        {
            return _fieldType;
        }
    }
}