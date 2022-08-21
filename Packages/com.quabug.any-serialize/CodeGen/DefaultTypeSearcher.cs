using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    internal interface ITypeSearcher
    {
        TypeReference Search(TypeTree typeTree, PropertyDefinition property, ILPostProcessorLogger logger = null);
    }
    
    internal class DefaultTypeSearcher : ITypeSearcher
    {
        public TypeReference Search(TypeTree typeTree, PropertyDefinition property, ILPostProcessorLogger logger = null)
        {
            var module = property.Module;
            var anyDef = module.ImportReference(typeof(IAny)).Resolve();
            var isReadOnly = property.SetMethod == null;
            var attribute = property.GetAttributesOf<AnySerializeAttribute>().Single();
            var baseType = (Type)attribute.ConstructorArguments[AnySerializeAttribute.SearchingBaseTypeIndex].Value
                ?? (isReadOnly ? typeof(IReadOnlyAny<>) : typeof(IAny<>))
            ;
            Assert.IsTrue(typeof(IAny<>).IsAssignableFrom(baseType) || typeof(IReadOnlyAny<>).IsAssignableFrom(baseType));
            var baseTypeReference = module.ImportReference(baseType);
            logger?.Warning($"{baseTypeReference.FullName}<{string.Join(",", baseTypeReference.GenericParameters.Select(g => g.Name))}> {property.FullName}");
            // TODO: only support base type with one and only one property type parameter?
            Assert.IsTrue(baseTypeReference.GenericParameters.Count == 1);
            var propertyType = property.PropertyType;
            var targetType = baseTypeReference.MakeGenericInstanceType(propertyType);
            var propertyFields = GetNonStaticFields(propertyType.Resolve());
            TypeReference closestType = null;
            TypeReference closestImplementation = null;
            foreach (var (type, implementation) in FindTypes(targetType, targetType.ElementType.GenericParameters[0]))
            {
                if (!IsInstantializable(type)) continue;
            }
            return FindClosestTargetType();

            bool IsCloserImplementation(TypeReference previous, TypeReference current, TypeReference target)
            {
                if (previous == null || previous.IsGenericParameter) return true;
                if (current == null || current.IsGenericParameter) return false;
                var previousDefinition = previous.Resolve();
                var currentDefinition = current.Resolve();
                
                if (previousRank != currentRank) return previousRank < currentRank;
                if (CalcTypeDistance(previous, propertyType) < CalcTypeDistance(current, propertyType)) return true;
            }

            int TypeHierarchyDistance(TypeDefinition from, TypeDefinition to)
            {
                const int MaxTypeHierarchy = 10000;
                if (from.IsTypeEqual(to)) return 0;
                
                if (to.IsInterface && from.HasInterfaces && from.Interfaces.Any(i => ))
                if (!to.IsInterface && from.BaseType == null) return MaxTypeHierarchy;
                if (to.IsInterface && !from.HasInterfaces) return MaxTypeHierarchy;
                
                
                
                var distance = 0;
                while (!from.IsTypeEqual(to))
                {
                    distance++;
                    
                }
            }

            bool IsInstantializable(TypeReference type)
            {
                var def = type.Resolve();
                if (def.IsAbstract) return false;
                if (def.GetConstructors().FirstOrDefault(ctor => !ctor.HasParameters) == null) return false;
                var isAnyClass = def.IsDerivedFrom(module.ImportReference(typeof(IAnyClass)).Resolve());
                var cannotResolvedTypeCount = type.GetGenericParametersOrArguments()
                    .Count(arg => arg is GenericParameter genericParameter && !HasConstraintOfAny(genericParameter))
                ;
                if (!isAnyClass && cannotResolvedTypeCount > 0) return false;
                if (isAnyClass && cannotResolvedTypeCount != propertyFields.Count) return false;
                return true;
            }

            bool HasConstraintOfAny(GenericParameter genericParameter)
            {
                return genericParameter.HasConstraints && genericParameter.Constraints.Select(constraint => constraint.ConstraintType.Resolve())
                    .Any(constraint => constraint.IsDerivedFrom(anyDef))
                ;
            }

            IReadOnlyList<FieldDefinition> GetNonStaticFields(TypeDefinition type)
            {
                return type.HasFields ? type.Fields.Where(field => !field.IsStatic).ToArray() : Array.Empty<FieldDefinition>();
            }

            IEnumerable<(TypeReference type, TypeReference t)> FindTypes(TypeReference target, TypeReference t)
            {
                foreach (var (type, implementation) in typeTree.GetOrCreateDirectDerivedReferences(target))
                {
                }
            }
        }
    }
}