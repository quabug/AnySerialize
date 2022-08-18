using System;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    internal static class TypeEqualExtension
    {
        [Pure]
        public static bool IsTypeEqual([NotNull] this TypeReference lhs, [NotNull] TypeReference rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            
            // generic parameter
            if (lhs.IsGenericParameter && rhs.IsGenericParameter) return true;
            if (lhs.IsGenericParameter || rhs.IsGenericParameter) return false;
            
            // generic instance
            if (lhs.IsGenericInstance && rhs.IsGenericInstance) return IsTypeEqual((GenericInstanceType)lhs, (GenericInstanceType)rhs);
            if (lhs.IsGenericInstance || rhs.IsGenericInstance) return false;
            
            // array
            if (lhs.IsArray && rhs.IsArray) return IsTypeEqual(lhs.GetElementType(), rhs.GetElementType());
            if (lhs.IsArray || rhs.IsArray) return false;
            
            // definition
            return IsTypeEqual(lhs.Resolve(), rhs.Resolve());
        }

        [Pure]
        public static bool IsTypeEqual([NotNull] this TypeDefinition lhs, [NotNull] TypeDefinition rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return lhs.MetadataToken == rhs.MetadataToken && lhs.Module.Name == rhs.Module.Name;
        }
        
        [Pure]
        public static bool IsTypeEqual([NotNull] this GenericInstanceType lhs, [NotNull] GenericInstanceType rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            if (lhs.GenericArguments.Count != rhs.GenericArguments.Count) return false;
            if (!IsTypeEqual(lhs.Resolve(), rhs.Resolve())) return false;
            return !lhs.GenericArguments.Where((t, i) => !t.IsTypeEqual(rhs.GenericArguments[i])).Any();
        }
    }
}