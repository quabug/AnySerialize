using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    internal static class TypeGenericExtension
    {
        [Pure]
        public static bool IsConcreteType([NotNull] this TypeReference type)
        {
            if (type == null) throw new ArgumentNullException();
            if (type.IsGenericParameter) return false;
            if (type.IsArray) return IsConcreteType(type.GetElementType());
            if (!type.IsGenericType()) return true;
            return type.IsGenericInstance && ((GenericInstanceType)type).IsConcreteType();
        }

        [Pure]
        public static bool IsConcreteType([NotNull] this GenericInstanceType type)
        {
            if (type == null) throw new ArgumentNullException();
            return type.GenericArguments.All(arg => arg.IsConcreteType());
        }

        [Pure]
        public static bool IsGenericType([NotNull] this TypeReference type)
        {
            if (type == null) throw new ArgumentNullException();
            return type.HasGenericParameters || type.IsGenericInstance;
        }

        [Pure]
        public static bool IsPartialGenericMatch(this GenericInstanceType partial, GenericInstanceType concrete)
        {
            if (!partial.Resolve().IsTypeEqual(concrete.Resolve()))
                throw new ArgumentException($"{partial} and {concrete} have different type");
            return IsPartialGenericMatch(partial.GenericArguments, concrete.GenericArguments);
        }
        
        [Pure]
        public static bool IsPartialGenericMatch(this IList<TypeReference> partial, IList<TypeReference> concrete)
        {
            if (partial.Count != concrete.Count)
                throw new ArgumentException($"{partial} and {concrete} have different count of generic arguments");
            if (concrete.Any(arg => arg.IsGenericParameter))
                throw new ArgumentException($"{concrete} is not a concrete generic type");

            return partial
                .Zip(concrete, (partialArgument, concreteArgument) => (partialArgument, concreteArgument))
                .All(t => t.partialArgument.IsGenericParameter || t.partialArgument.IsTypeEqual(t.concreteArgument))
            ;
        }
        
        // TODO: Covariant and contravariant?
        [Pure]
        public static bool IsPartialGenericTypeOf([NotNull] this TypeReference partial, [NotNull] TypeReference generic)
        {
            if (partial == null || generic == null) throw new ArgumentNullException();
            if (partial.IsArray || generic.IsArray) throw new ArgumentException();
            if (partial.IsGenericParameter || generic.IsGenericParameter) return generic.IsGenericParameter;
            if (!partial.IsGenericType() && !generic.IsGenericType()) return partial.Resolve().IsTypeEqual(generic.Resolve());
            if (!partial.IsGenericType() || !generic.IsGenericType()) return false;
            var partialArguments = partial.GetGenericParametersOrArguments();
            var genericArguments = generic.GetGenericParametersOrArguments();
            return partial.Resolve().IsTypeEqual(generic.Resolve()) && 
                   partialArguments.Zip(genericArguments, (p, g) => (p, g)).All(t => t.p.IsPartialGenericTypeOf(t.g));
        }

        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<TypeReference> GetGenericParametersOrArguments([NotNull] this TypeReference type)
        {
            if (type.HasGenericParameters) return type.GenericParameters;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).GenericArguments;
            return Enumerable.Empty<TypeReference>();
        }
        
        public static void GetGenericParametersOrArguments([NotNull] this TypeReference type, [NotNull] IList<TypeReference> arguments)
        {
            var i = 0;
            foreach (var arg in type.GetGenericParametersOrArguments())
            {
                arguments[i] = arg;
                i++;
            }
        }
        
        [Pure]
        public static int GetGenericParametersOrArgumentsCount([NotNull] this TypeReference type)
        {
            if (type.HasGenericParameters) return type.GenericParameters.Count;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).GenericArguments.Count;
            return 0;
        }
    }
}