using System;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    public class PropertyCodeGenOrConstraintTypeSearcher : ITypeSearcher<AnyPropertyCodeGenOrConstraintTypeAttribute>
    {
        private readonly TypeReference? _result;
        
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
            
            var attributeType = module.ImportReference(typeof(IAnyCodeGenAttribute))!;
            var field = fields[fieldIndex];
            var property = field.GetBackingFieldProperty();
            var codeGenAttribute = property?.CustomAttributes?.FirstOrDefault(attribute => attribute.AttributeType!.IsDerivedFrom(attributeType));
            
            if (codeGenAttribute != null)
            {
                _result = container.Search(
                    codeGenAttribute,
                    (property!, typeof(TargetLabel<>))
                );
            }
            else
            {
                var constraint = parameter.Constraints[0]!.ConstraintType;
                var constraintType = constraint.FillGenericTypesByReferenceGenericName(genericType);
                if (constraintType.IsConcreteType()) _result = container.FindClosestType(constraintType);
                logger.Debug($"[{GetType()}] {parameter.Name}:{constraintType}={_result}");
            }
            
        }
        
        public TypeReference? Search()
        {
            return _result;
        }
    }
}