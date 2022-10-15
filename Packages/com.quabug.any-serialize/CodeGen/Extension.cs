using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using OneShot;

namespace AnySerialize.CodeGen
{
    public static class Extension
    {
        public static TypeReference? CreateConcreteTypeFrom(this Container container, TypeReference type)
        {
            var def = type.Resolve();
            if (def == null) return null;
            if (def.IsAbstract) return null;
            if (!def.IsValueType && def.GetConstructors()!.FirstOrDefault(ctor => !ctor.HasParameters) == null) return null;
            if (type.IsConcreteType()) return type;

            if (type is not GenericInstanceType genericType)
                throw new ArgumentException($"{nameof(type)}({type}) must be a {nameof(GenericInstanceType)}", nameof(type));
            
            var anyGenericParameterSearcherAttributeType = type.Module!.ImportReference(typeof(IAnyGenericParameterSearcherAttribute))!;
                    
            for (var i = 0; i < genericType.GenericArguments!.Count; i++)
            {
                var arg = genericType.GenericArguments[i]!;
                if (arg is GenericParameter parameter)
                {
                    if (!parameter.HasCustomAttributes) return null;
                    var attribute = parameter.CustomAttributes!
                        .FirstOrDefault(attr => attr.AttributeType!.IsDerivedFrom(anyGenericParameterSearcherAttributeType))
                    ;
                    if (attribute == null) return null;
                    var genericArgument = container.Search(
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
        
        public static TypeReference CreateAnySerializePropertyType(this PropertyDefinition property, ILPostProcessorLogger? logger = null)
        {
            var isReadOnly = property.SetMethod == null;
            var baseType = isReadOnly ? typeof(IReadOnlyAny<>) : typeof(IAny<>);
            var baseTypeReference = property.Module!.ImportReference(baseType)!;
            logger?.Info($"create property {baseTypeReference.FullName}<{string.Join(",", baseTypeReference.GenericParameters!.Select(g => g.Name))}> {property.FullName}");
            return baseTypeReference.MakeGenericInstanceType(property.PropertyType!)!;
        }
        
        public static TypeReference? FindClosestType(
            this Container container,
            TypeReference targetType
        )
        {
            if (!targetType.IsGenericInstance || !targetType.IsConcreteType() || targetType.GetGenericParametersOrArgumentsCount() != 1)
                throw new ArgumentException($"{nameof(targetType)} must be a concrete generic instance with one and only one arguments.", nameof(targetType));
            
            var propertyType = targetType.GetGenericParametersOrArguments().First();
            if (propertyType is ArrayType { Rank: > 1 })
                throw new ArgumentException($"Invalid property type ({propertyType}): array type with rank is not supported yet.", nameof(targetType));

            var module = container.Resolve<ModuleDefinition>();
            var logger = container.Resolve<ILPostProcessorLogger>();
            var typeTree = container.Resolve<TypeTree>();
            
            var hasAnySerializableAttribute = propertyType.Resolve()!.GetAttributesOf<AnySerializableAttribute>().Any();
            var anyClassInterface = module.ImportReference(typeof(IReadOnlyAnyClass<>))!.Resolve()!;
            
            TypeReference? closestType = null;
            TypeReference? closestImplementation = null;
            var closestPriority = int.MaxValue;
            foreach (var (type, implementation) in FindTypes(targetType, ((GenericInstanceType)targetType).ElementType.GenericParameters[0]!).Append((targetType, null)))
            {
                if (!hasAnySerializableAttribute && type.Resolve()!.IsDerivedFrom(anyClassInterface)) continue;
                
                var priorityAttribute = type.Resolve()!.GetAttributesOf<AnySerializePriorityAttribute>().SingleOrDefault();
                var priority = priorityAttribute == null ? 0 : (int)priorityAttribute.ConstructorArguments![0].Value;
                if (priority > closestPriority) continue;
                if (closestPriority == priority && !IsCloserImplementation(closestImplementation, implementation, propertyType)) continue;
                
                var concreteType = container.CreateConcreteTypeFrom(type);
                if (concreteType == null) continue;
                
                logger.Debug($"[{nameof(FindClosestType)}] create concreteType {concreteType} from {type}");
                
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
                foreach (var (type, implementation) in typeTree.GetOrCreateDirectDerivedReferences(target))
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