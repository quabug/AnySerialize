using AnyProcessor.CodeGen;
using Mono.Cecil;
using OneShot;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    public class ConstraintTypeSearcher : ITypeSearcher<AnyConstraintTypeAttribute>
    {
        private readonly TypeReference _result;
        
        public ConstraintTypeSearcher(
            Container container,
            [Inject(typeof(GenericLabel<>))] GenericInstanceType genericType,
            [Inject(typeof(GenericLabel<>))] GenericParameter parameter
        )
        {
            Assert.AreEqual(1, parameter.Constraints.Count);
            var constraint = parameter.Constraints[0].ConstraintType;
            var constraintType = constraint.FillGenericTypesByReferenceGenericName(genericType);
            if (constraintType.IsConcreteType())
            {
                container = container.CreateChildContainer();
                var label = typeof(TargetLabel<>);
                container.RegisterInstance(constraintType).AsSelf(label).AsBases(label);
                _result = container.Search<SerializeTypeSearcher>();
            }
        }
        
        public TypeReference Search()
        {
            return _result;
        }
    }
}