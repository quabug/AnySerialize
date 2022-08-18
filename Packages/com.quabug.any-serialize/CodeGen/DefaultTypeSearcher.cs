using System;
using System.Linq;
using Mono.Cecil;
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
            var isReadOnly = property.SetMethod == null;
            var attribute = property.GetAttributesOf<AnySerializeAttribute>().Single();
            var baseType = (Type)attribute.ConstructorArguments[AnySerializeAttribute.SearchingBaseTypeIndex].Value
                ?? (isReadOnly ? typeof(IReadOnlyAny<>) : typeof(IAny<>))
            ;
            var baseTypeReference = property.Module.ImportReference(baseType);
            logger?.Warning($"{baseTypeReference.FullName}<{string.Join(",", baseTypeReference.GenericParameters.Select(g => g.Name))}> {property.FullName}");
            // TODO: only support base type with one and only one property typeDef parameter?
            Assert.IsTrue(baseTypeReference.GenericParameters.Count == 1);
            var propertyTypeParameter = baseTypeReference.GenericParameters[0];
            var targetType = new GenericInstanceType(baseTypeReference);
            targetType.GenericArguments.Add(property.PropertyType);
            var matchTypes = typeTree.GetOrCreateAllDerivedReference(targetType).ToArray();
            return null;
            // logger?.Warning($"{propertyTypeParameter?.FullName} {matchType?.Type.Name}");
            // return matchType?.Type;
        }
    }
}