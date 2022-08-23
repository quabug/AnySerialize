using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    internal class DefaultTypeSearcher : ITypeSearcher
    {
        private readonly TypeTree _typeTree;
        private readonly ModuleDefinition _module;
        private readonly ICodeGenLogger _logger;
        private readonly TypeDefinition _anyDef;

        public DefaultTypeSearcher(TypeTree typeTree, ModuleDefinition module, ICodeGenLogger logger = null)
        {
            _typeTree = typeTree;
            _module = module;
            _logger = logger;
            _anyDef = _module.ImportReference(typeof(IAny)).Resolve();
        }
        
        public TypeReference Search(TypeReference targetType)
        {
            // var isReadOnly = property.SetMethod == null;
            // var attribute = property.GetAttributesOf<AnySerializeAttribute>().Single();
            // var baseType = (Type)attribute.ConstructorArguments[AnySerializeAttribute.SearcherIndex].Value
            //     ?? (isReadOnly ? typeof(IReadOnlyAny<>) : typeof(IAny<>))
            // ;
            // Assert.IsTrue(typeof(IAny<>).IsAssignableFrom(baseType) || typeof(IReadOnlyAny<>).IsAssignableFrom(baseType));
            // var baseTypeReference = _module.ImportReference(baseType);
            // _logger?.Warning($"{baseTypeReference.FullName}<{string.Join(",", baseTypeReference.GenericParameters.Select(g => g.Name))}> {property.FullName}");
            // // TODO: only support base type with one and only one property type parameter?
            // Assert.IsTrue(baseTypeReference.GenericParameters.Count == 1);
            // var propertyType = property.PropertyType;
            // var targetType = baseTypeReference.MakeGenericInstanceType(propertyType);
            
            Assert.IsTrue(targetType.IsGenericInstance);
            Assert.IsTrue(targetType.IsConcreteType());
            Assert.IsTrue(targetType.GetGenericParametersOrArgumentsCount() == 1);
            
            var propertyType = targetType.GetGenericParametersOrArguments().First();
            var propertyFields = GetNonStaticFields(propertyType.Resolve());
            TypeReference closestType = null;
            TypeReference closestImplementation = null;
            foreach (var (type, implementation) in FindTypes(targetType, ((GenericInstanceType)targetType).ElementType.GenericParameters[0]))
            {
                if (IsInstantializable(type) && IsCloserImplementation(closestImplementation, implementation, propertyType))
                {
                    closestImplementation = implementation;
                    closestType = type;
                }
            }

            if (closestType != null && !closestType.IsConcreteType())
            {
                // TODO: use different `Searcher`s on generic types
                var arguments = closestType.GetGenericParametersOrArguments().ToArray();
                var parameters = closestType.GetGenericParameters().ToArray();
                var fieldIndex = 0;
                for (var i = 0; i < arguments.Length; i++)
                {
                    var arg = arguments[i];
                    if (!(arg is GenericParameter parameter)) continue;
                    if (parameter.HasConstraints)
                    {
                        Assert.IsTrue(parameter.Constraints.Count == 1);
                        var constraintType = parameter.Constraints[0].ConstraintType.FillGenericTypesByReferenceGenericName(parameters, arguments);
                        arguments[i] = new DefaultTypeSearcher(_typeTree, _module, _logger).Search(constraintType);
                    }
                    else
                    {
                        arguments[i] = propertyFields[fieldIndex].FieldType;
                        fieldIndex++;
                    }
                }
                closestType = closestType.Resolve().MakeGenericInstanceType(arguments);
            }
            return closestType;

            bool IsCloserImplementation(TypeReference previous, TypeReference current, TypeReference target)
            {
                if (previous == null || previous.IsGenericParameter) return true;
                if (current == null || current.IsGenericParameter) return false;
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

            bool IsInstantializable(TypeReference type)
            {
                var def = type.Resolve();
                if (def.IsAbstract) return false;
                if (def.GetConstructors().FirstOrDefault(ctor => !ctor.HasParameters) == null) return false;
                var isAnyClass = def.IsDerivedFrom(_module.ImportReference(typeof(IAnyClass)).Resolve());
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
                    .Any(constraint => constraint.IsDerivedFrom(_anyDef))
                ;
            }

            IReadOnlyList<FieldDefinition> GetNonStaticFields(TypeDefinition type)
            {
                return type.HasFields ? type.Fields.Where(field => !field.IsStatic).ToArray() : Array.Empty<FieldDefinition>();
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