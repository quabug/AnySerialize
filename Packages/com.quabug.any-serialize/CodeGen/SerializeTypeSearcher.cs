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
        private readonly PropertyDefinition _property;
        private readonly ILPostProcessorLogger _logger;
        private readonly TypeReference? _baseType;

        public SerializeTypeSearcher(
            Container container,
            TypeTree typeTree,
            [Inject(typeof(TargetLabel<>))] PropertyDefinition property,
            ILPostProcessorLogger logger,
            [Inject(typeof(AttributeLabel<>))] TypeReference? baseType = null
        )
        {
            _container = container;
            _property = property;
            _logger = logger;
            _baseType = baseType;
        }

        public TypeReference? Search()
        {
            var targetType = _baseType ?? _property.CreateAnySerializePropertyType(_logger);
            _logger.Debug($"[{GetType()}] search {targetType}({_property.PropertyType})");
            return _container.FindClosestType(targetType);
        }
    }
}