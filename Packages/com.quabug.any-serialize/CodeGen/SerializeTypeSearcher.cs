using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using JetBrains.Annotations;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    [UsedImplicitly]
    internal class SerializeTypeSearcher : ITypeSearcher<AnySerializeAttribute>
    {
        private readonly Container _container;
        private readonly ModuleDefinition _module;
        private readonly TypeTree _typeTree;
        private readonly TypeReference _targetType;
        private readonly ILPostProcessorLogger _logger;

        public SerializeTypeSearcher(
            Container container,
            ModuleDefinition module,
            TypeTree typeTree,
            [Inject(typeof(TargetLabel<>))] TypeReference targetType,
            ILPostProcessorLogger logger,
            [Inject(typeof(AttributeLabel<>))] TypeReference? baseType = null
        )
        {
            _container = container;
            _module = module;
            _typeTree = typeTree;
            _targetType = baseType ?? targetType;
            _logger = logger;
            logger.Debug($"[{GetType()}] create search of {_targetType}");
        }

        public TypeReference? Search()
        {
            if (!_targetType.IsGenericInstance || !_targetType.IsConcreteType() || _targetType.GetGenericParametersOrArgumentsCount() != 1)
                throw new ArgumentException($"{nameof(_targetType)} must be a concrete generic instance with one and only one arguments.", nameof(_targetType));
            
            var propertyType = _targetType.GetGenericParametersOrArguments().First();
            if (propertyType is ArrayType { Rank: > 1 })
                throw new ArgumentException($"Invalid property type ({propertyType}): array type with rank is not supported yet.", nameof(_targetType));
            
            var hasAnySerializableAttribute = propertyType.Resolve().GetAttributesOf<AnySerializableAttribute>().Any();
            var anyClassInterface = _module.ImportReference(typeof(IReadOnlyAnyClass<>)).Resolve();

            return _container.FindClosestType(
                _targetType,
                (type, _) => !hasAnySerializableAttribute && type.Resolve().IsDerivedFrom(anyClassInterface)
            );
        }
    }
}