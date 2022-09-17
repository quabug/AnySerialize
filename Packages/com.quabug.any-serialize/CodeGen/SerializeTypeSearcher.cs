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
            if (propertyType is ArrayType propertyArrayType && propertyArrayType.Rank > 1)
                throw new ArgumentException($"Invalid property type ({propertyType}): array type with rank is not supported yet.", nameof(_targetType));
            
            var isAnySerializable = propertyType.Resolve().GetAttributesOf<AnySerializableAttribute>().Any();
            var anyClassInterface = _module.ImportReference(typeof(IReadOnlyAnyClass<>)).Resolve();
            
            _logger.Debug($"[{GetType()}] search {_targetType}({propertyType})");
            
            TypeReference? closestType = null;
            TypeReference? closestImplementation = null;
            var closestPriority = int.MaxValue;
            foreach (var (type, implementation) in FindTypes(_targetType, ((GenericInstanceType)_targetType).ElementType.GenericParameters[0]!).Append((_targetType, null)))
            {
                if (!isAnySerializable && type.Resolve().IsDerivedFrom(anyClassInterface)) continue;
                
                var priorityAttribute = type.Resolve()!.GetAttributesOf<AnySerializePriorityAttribute>().SingleOrDefault();
                var priority = priorityAttribute == null ? 0 : (int)priorityAttribute.ConstructorArguments![0].Value;
                if (priority > closestPriority) continue;
                if (closestPriority == priority && !IsCloserImplementation(closestImplementation, implementation, propertyType)) continue;
                
                var concreteType = _container.CreateConcreteTypeFrom(type);
                if (concreteType == null) continue;
                
                _logger.Debug($"[{GetType()}] create concreteType {concreteType} from {type}");
                
                closestImplementation = implementation;
                closestType = type;
                closestPriority = priority;
            }
            return closestType;

            bool IsCloserImplementation(TypeReference? previous, TypeReference? current, TypeReference target)
            {
                if (previous == null || previous.IsGenericParameter) return true;
                if (current == null || current.IsGenericParameter) return false;
                if (previous.TypeEquals(current)) return true;
                if (previous is ArrayType previousArray && current is ArrayType currentArray && target is ArrayType targetArray)
                    return currentArray.Rank == targetArray.Rank && IsCloserImplementation(previousArray.ElementType, currentArray.ElementType, targetArray.ElementType!);
                if (current.IsArray && target.IsArray) return true;
                
                var previousDefinition = previous.Resolve()!;
                var currentDefinition = current.Resolve()!;
                var targetDefinition = target.Resolve()!;
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

            IEnumerable<(TypeReference type, TypeReference? implementation)> FindTypes(TypeReference target, TypeReference targetGeneric)
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