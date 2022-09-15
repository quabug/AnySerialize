using System;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    public class PropertyCodeGenOrConstraintTypeSearcher : ITypeSearcher<AnyPropertyCodeGenOrConstraintTypeAttribute>
    {
        private TypeReference? _result;
        
        public PropertyCodeGenOrConstraintTypeSearcher(
            ILPostProcessorLogger logger,
            Container container,
            ModuleDefinition module,
            [Inject(typeof(AttributeLabel<>))] string fieldDeclaringTypeParameterName,
            [Inject(typeof(GenericLabel<>))] GenericInstanceType genericType,
            [Inject(typeof(GenericLabel<>))] GenericParameter parameter
        )
        {
            if (parameter.Constraints!.Count != 1)
                throw new ArgumentException($"Must have and only have one constraint of {nameof(parameter)}", nameof(parameter));
            
            var fieldIndex = -1;
            var searcherFieldCount = 0;
            var genericTypeDefinition = genericType.Resolve()!;
            foreach (var genericParameter in genericTypeDefinition.GenericParameters!)
            {
                if (genericParameter.Name == parameter.Name)
                    fieldIndex = searcherFieldCount;
                
                if (genericParameter.GetAttributesOf<AnyPropertyCodeGenOrConstraintTypeAttribute>().Any())
                    searcherFieldCount++;
            }

            var declaringGenericIndex = genericTypeDefinition.GenericParameters.FindIndexOf(param => param.Name == fieldDeclaringTypeParameterName);
            var declaringType = genericType.GenericArguments![declaringGenericIndex]!;
            var fields =  AnyClassUtility.Reorder(
                declaringType.Resolve()!.Fields.Where(field => !field.IsStatic),
                field => (int?)field.GetAttributesOf<AnySerializeFieldOrderAttribute>().SingleOrDefault()?.ConstructorArguments[0].Value
            ).ToArray();
            if (searcherFieldCount != fields.Length || fieldIndex < 0) return;
            
            const string backingField = "k__BackingField";
            var attributeType = module.ImportReference(typeof(IAnyCodeGenAttribute))!;
            var field = fields[fieldIndex];
            var propertyName = field.Name.EndsWith(backingField) ? field.Name.Substring(1, field.Name.Length - backingField.Length - 2) : null;
            var property = declaringType.Resolve().Properties.FirstOrDefault(p => p.Name == propertyName);
            var codeGenAttribute = property?.CustomAttributes?.FirstOrDefault(attribute => attribute.AttributeType!.IsDerivedFrom(attributeType));
            
            var label = typeof(TargetLabel<>);
            if (codeGenAttribute != null)
            {
                var propertyType = property.CreateAnySerializePropertyType(logger);
                _result = container.Search(
                    codeGenAttribute,
                    (propertyType, label)
                );
            }
            else
            {
                var constraint = parameter.Constraints[0]!.ConstraintType;
                var constraintType = constraint.FillGenericTypesByReferenceGenericName(genericType);
                if (constraintType.IsConcreteType())
                {
                    container = container.CreateChildContainer();
                    container.RegisterInstance(constraintType)!.AsSelf(label).AsBases(label);
                    _result = container.Search<SerializeTypeSearcher>();
                }
                logger.Debug($"[{GetType()}] {parameter.Name}:{constraintType}={_result}");
            }
            
        }
        
        public TypeReference? Search()
        {
            return _result;
        }
    }
}