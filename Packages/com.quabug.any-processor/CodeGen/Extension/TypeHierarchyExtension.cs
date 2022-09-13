using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnyProcessor.CodeGen
{
    public static class TypeHierarchyExtension
    {
        [Pure]
        public static IEnumerable<TypeReference> GetInterfaces(this TypeDefinition type)
        {
            if (type.HasInterfaces) foreach (var @interface in type.Interfaces) yield return @interface.InterfaceType;
        }
        
        [Pure]
        public static IEnumerable<TypeReference> GetBaseAndInterfaces(this TypeDefinition type)
        {
            if (type.BaseType != null) yield return type.BaseType;
            foreach (var @interface in type.GetInterfaces()) yield return @interface;
        }
        
        [Pure]
        public static IEnumerable<TypeDefinition> GetAllBaseDefinitions(this TypeDefinition type)
        {
            return type.GetSelfAndAllBaseDefinitions().Skip(1);
        }
        
        [Pure]
        public static IEnumerable<TypeReference> GetAllBaseReferences(this TypeReference type)
        {
            return type.GetSelfAndAllBaseReferences().Skip(1);
        }
        
        [Pure]
        public static IEnumerable<TypeReference> GetSelfAndAllBaseReferences(this TypeReference type)
        {
            while (type != null)
            {
                yield return type;
                type = type.Resolve().BaseType;
            }
        }
        
        [Pure]
        public static IEnumerable<TypeDefinition> GetSelfAndAllBaseDefinitions(this TypeDefinition type)
        {
            return type.GetSelfAndAllBaseReferences().Select(t => t.Resolve());
        }

        [Pure]
        public static IEnumerable<TypeReference> GetAllBasesAndInterfaces(this TypeDefinition type)
        {
            return type.GetSelfAndAllBaseDefinitions().SelectMany(t => t.GetBaseAndInterfaces());
        }

        [Pure]
        public static IEnumerable<TypeReference> GetAllInterfaces(this TypeDefinition type)
        {
            return type.GetSelfAndAllBaseDefinitions().SelectMany(t => t.GetInterfaces());
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

        [Pure]
        public static IEnumerable<TypeDefinition> GetSelfAndAllDeclaringTypes(this TypeDefinition type)
        {
            yield return type;
            while (type.DeclaringType != null)
            {
                yield return type.DeclaringType;
                type = type.DeclaringType;
            }
        }
        
        [Pure]
        public static IEnumerable<TypeReference> GetSelfAndAllBasesWithConcreteGenericType(this TypeReference type)
        {
            var self = type;
            yield return self;
            foreach (var @base in type.GetAllBaseReferences())
            {
                self = self is GenericInstanceType genericInstanceType ? @base.FillGenericTypesByReferenceGenericName(genericInstanceType) : @base;
                yield return self;
            }
        }
    }
}