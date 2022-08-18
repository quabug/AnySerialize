using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    internal static class TypeHierarchyExtension
    {
        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<TypeReference> GetParentTypes([NotNull] this TypeDefinition type)
        {
            if (type.BaseType != null) yield return type.BaseType;
            if (type.HasInterfaces) foreach (var @interface in type.Interfaces) yield return @interface.InterfaceType;
        }
        
        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<TypeReference> GetAllBases([NotNull] this TypeDefinition type)
        {
            var baseType = type.BaseType;
            while (baseType != null)
            {
                yield return baseType;
                baseType = baseType.Resolve().BaseType;
            }
        }

        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<TypeReference> GetAllInterfacesAndBases([NotNull] this TypeDefinition type)
        {
            foreach (var parentType in type.GetParentTypes())
            {
                yield return parentType;
                foreach (var t in GetAllInterfacesAndBases(parentType.Resolve())) yield return t;
            }
        }

        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<TypeReference> GetAllInterfaces([NotNull] this TypeDefinition type)
        {
            return type.GetAllInterfacesAndBases().Where(t => t.Resolve().IsInterface);
        }

        [Pure]
        public static bool IsPublicOrNestedPublic(this TypeDefinition type)
        {
            foreach (var t in type.GetSelfAndAllDeclaringTypes())
            {
                if ((t.IsNested && !t.IsNestedPublic) || (!t.IsNested && !t.IsPublic)) return false;
            }
            return true;
        }

        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<TypeDefinition> GetSelfAndAllDeclaringTypes(this TypeDefinition type)
        {
            yield return type;
            while (type.DeclaringType != null)
            {
                yield return type.DeclaringType;
                type = type.DeclaringType;
            }
        }
    }
}