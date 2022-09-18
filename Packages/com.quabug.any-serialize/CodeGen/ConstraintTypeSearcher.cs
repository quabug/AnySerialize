using System;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    public class ConstraintTypeSearcher : ITypeSearcher<AnyConstraintTypeAttribute>
    {
        private readonly TypeReference? _result;
        
        public ConstraintTypeSearcher(
            Container container,
            ILPostProcessorLogger logger,
            [Inject(typeof(GenericLabel<>))] GenericInstanceType genericType,
            [Inject(typeof(GenericLabel<>))] GenericParameter parameter
        )
        {
            if (parameter.Constraints!.Count != 1)
                throw new ArgumentException($"Must have and only have one constraint of {nameof(parameter)}", nameof(parameter));
            var constraint = parameter.Constraints[0]!.ConstraintType;
            var constraintType = constraint.FillGenericTypesByReferenceGenericName(genericType);
            if (constraintType.IsConcreteType()) _result = container.FindClosestType(constraintType);
            logger.Debug($"[{GetType()}] {parameter.Name}:{constraintType}={_result}");
        }
        
        public TypeReference? Search()
        {
            return _result;
        }
    }
}