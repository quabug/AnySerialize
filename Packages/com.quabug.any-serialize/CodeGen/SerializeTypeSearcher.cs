using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using OneShot;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    [UsedImplicitly]
    internal class SerializeTypeSearcher : ITypeSearcher<AnySerializeAttribute>
    {
        private readonly Container _container;
        private readonly TypeTree _typeTree;
        private readonly ModuleDefinition _module;
        private readonly TypeReference _targetType;
        private readonly ILPostProcessorLogger _logger;

        public SerializeTypeSearcher(
            Container container,
            TypeTree typeTree,
            ModuleDefinition module,
            [Inject(typeof(TargetLabel<>))] TypeReference targetType,
            ILPostProcessorLogger logger
        )
        {
            _container = container;
            _typeTree = typeTree;
            _module = module;
            _targetType = targetType;
            _logger = logger;
        }

        public TypeReference Search()
        {
            Assert.IsTrue(_targetType.IsGenericInstance);
            Assert.IsTrue(_targetType.IsConcreteType());
            Assert.IsTrue(_targetType.GetGenericParametersOrArgumentsCount() == 1);

            var anyGenericParameterSearcherAttributeType = _module.ImportReference(typeof(IAnyGenericParameterSearcherAttribute));
            
            var propertyType = _targetType.GetGenericParametersOrArguments().First();
            TypeReference closestType = null;
            TypeReference closestImplementation = null;
            foreach (var (type, implementation) in FindTypes(_targetType, ((GenericInstanceType)_targetType).ElementType.GenericParameters[0]))
            {
                if (!IsCloserImplementation(closestImplementation, implementation, propertyType)) continue;
                
                var concreteType = CreateConcreteTypeFrom(type);
                if (concreteType == null) continue;
                
                closestImplementation = implementation;
                closestType = type;
            }
            return closestType;

            bool IsCloserImplementation(TypeReference previous, TypeReference current, TypeReference target)
            {
                if (previous == null || previous.IsGenericParameter) return true;
                if (current == null || current.IsGenericParameter) return false;
                if (previous.TypeEquals(current)) return true;
                if (previous is ArrayType previousArray && current is ArrayType currentArray && target is ArrayType targetArray)
                    return IsCloserImplementation(previousArray.ElementType, currentArray.ElementType, targetArray.ElementType);
                if (current.IsArray && target.IsArray) return true;
                
                var previousDefinition = previous.Resolve();
                var currentDefinition = current.Resolve();
                var targetDefinition = target.Resolve();
                var previousDistance = TypeHierarchyDistance(previousDefinition, target) ?? TypeHierarchyDistance(targetDefinition, previous);
                var currentDistance = TypeHierarchyDistance(currentDefinition, target) ?? TypeHierarchyDistance(targetDefinition, current);
                if (!previousDistance.HasValue && !currentDistance.HasValue) return true;
                if (!previousDistance.HasValue) return true;
                if (!currentDistance.HasValue) return false;
                if (previousDistance != currentDistance) return currentDistance < previousDistance;
                // TODO: find a better way to compare generic type implementations?
                return current.GetGenericParametersOrArguments().Count(generic => generic.IsGenericParameter)
                       <= previous.GetGenericParametersOrArguments().Count(generic => generic.IsGenericParameter)
                ;
            }

            int? TypeHierarchyDistance(TypeDefinition from, TypeReference to)
            {
                var distance = 0;
                foreach (var type in from.GetSelfAndAllBaseDefinitions())
                {
                    if (type.GetBaseAndInterfaces().Any(to.IsPartialGenericTypeOf))
                        return distance;
                    distance++;
                }
                return null;
            }

            TypeReference CreateConcreteTypeFrom(TypeReference type)
            {
                var def = type.Resolve();
                if (def.IsAbstract) return null;
                if (def.GetConstructors().FirstOrDefault(ctor => !ctor.HasParameters) == null) return null;
                if (type.IsConcreteType()) return type;
                Assert.IsTrue(type.IsGenericInstance);
                var genericType = (GenericInstanceType)type;
                for (var i = 0; i < genericType.GenericArguments.Count; i++)
                {
                    var arg = genericType.GenericArguments[i];
                    if (arg is GenericParameter parameter)
                    {
                        if (!parameter.HasCustomAttributes) return null;
                        var attribute = parameter.CustomAttributes
                            .FirstOrDefault(attribute => attribute.AttributeType.IsDerivedFrom(anyGenericParameterSearcherAttributeType))
                        ;
                        if (attribute == null) return null;
                        var genericArgument = _container.Search(
                            attribute,
                            (parameter, typeof(GenericLabel<>)),
                            (genericType, typeof(GenericLabel<>))
                        );
                        if (genericArgument == null) return null;
                        genericType.GenericArguments[i] = genericArgument;
                    }
                    else if (!arg.IsConcreteType())
                    {
                        throw new NotSupportedException();
                    }
                }
                return genericType;
            }

            IEnumerable<(TypeReference type, TypeReference typeGeneric)> FindTypes(TypeReference target, TypeReference targetGeneric)
            {
                foreach (var (type, implementation) in _typeTree.GetOrCreateDirectDerivedReferences(target))
                {
                    if (implementation is GenericInstanceType genericImplementation)
                        targetGeneric = targetGeneric.FillGenericTypesByReferenceGenericName(genericImplementation);
                    yield return (type, targetGeneric);
                    foreach (var t in FindTypes(type, targetGeneric)) yield return t;
                }
            }
        }
    }
}