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
            var targetType = baseTypeReference.MakeGenericInstanceType(property.PropertyType);
            var propertyFields = GetNonStaticFields(property.PropertyType.Resolve());
            TypeReference closestType = null;
            // foreach (var type in typeTree.GetOrCreateAllDerivedReferences(targetType))
            // {
            //     if (!IsInstantializable(type)) continue;
            //     
            //     if (!type.IsGenericType())
            //     {
            //         closestType = type;
            //         break;
            //     }
            // }
            return closestType;

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
        }
    }
}