using System;
using System.Linq;
using Mono.Cecil;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    internal interface ITypeSearcher
    {
        TypeDefinition Search(TypeTree typeTree, Type baseType, PropertyDefinition property, ILPostProcessorLogger logger = null);
    }
    
    internal class DefaultTypeSearcher : ITypeSearcher
    {
        public TypeDefinition Search(TypeTree typeTree, Type baseType, PropertyDefinition property, ILPostProcessorLogger logger = null)
        {
            var baseTypeDefinition = property.Module.ImportReference(baseType).Resolve();
            logger?.Warning($"{baseTypeDefinition.FullName}<{string.Join(",", baseTypeDefinition.GenericParameters.Select(g => g.Name))}> {property.FullName}");
            // TODO: only support base typeDef with one and only one property typeDef parameter?
            Assert.IsFalse(baseTypeDefinition.IsGenericInstance && baseTypeDefinition.GenericParameters.Count == 1);
            var propertyTypeParameter = baseTypeDefinition.GenericParameters[0];
            var matchType = typeTree.FindMostMatchType(new TypeDef(baseTypeDefinition, property.PropertyType.Yield()));
            logger?.Warning($"{propertyTypeParameter.FullName} {matchType.Type.Name}");
            return matchType.Type;
        }
    }
}