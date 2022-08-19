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
            return type switch
            {
                null => throw new ArgumentNullException(),
                GenericParameter => false,
                GenericInstanceType genericInstanceType => genericInstanceType.GenericArguments.All(arg => arg.IsConcreteType()),
                TypeSpecification typeSpecification => typeSpecification.ElementType.IsConcreteType(),
                _ => !type.HasGenericParameters
            };
        }

        [Pure]
        public static bool IsGenericType([NotNull] this TypeReference type)
        {
            return type switch
            {
                null => throw new ArgumentNullException(),
                GenericParameter => true,
                GenericInstanceType => true,
                _ => type.HasGenericParameters
            };
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

        [Pure]
        public static bool IsMatchTypeConstraints([NotNull] this TypeReference type)
        {
            return type switch
            {
                GenericInstanceType genericInstanceType => genericInstanceType.GenericArguments
                    .Zip(genericInstanceType.ElementType.GenericParameters, (argument, parameter) => (argument, parameter))
                    .All(t => IsArgumentMatch(t.argument, t.parameter)),
                _ => true
            };
        
            static bool IsArgumentMatch(TypeReference genericArgument, GenericParameter genericParameter)
            {
                if (!genericParameter.HasConstraints) return true;
                if (genericArgument.IsGenericParameter) return true;
                return genericParameter.Constraints.Select(constraint => constraint.ConstraintType).All(genericArgument.IsDerivedFrom);
            }
        }

        // TODO: covariant/contravariant
        [Pure]
        public static bool IsDerivedFrom([NotNull] this TypeReference derived, [NotNull] TypeReference @base)
        {
            // TODO:
            return derived.Resolve().IsDerivedFrom(@base.Resolve());
        }
        
        [Pure]
        public static bool IsDerivedFrom([NotNull] this TypeDefinition derived, [NotNull] TypeDefinition @base)
        {
            return derived.GetAllInterfacesAndBases().Any(type => type.Resolve().IsTypeEqual(@base));
        }

        public static bool IsImplementationOf(this TypeReference self, TypeReference generic)
        {
            return self.GetImplementationsOf(generic).Any();
        }
        
        public static IEnumerable<TypeReference> GetImplementationsOf(this TypeReference self, TypeReference @base)
        {
            var selfDef = self.Resolve();
            var genericDef = @base.Resolve();
            foreach (var parentType in selfDef.GetParentTypes())
            {
                if (!parentType.Resolve().IsTypeEqual(genericDef)) continue;
                if (!parentType.IsGenericType())
                    yield return parentType;
                else if (parentType.GetGenericParametersOrArguments().Zip(@base.GetGenericParametersOrArguments(), (s, g) => (s, g)).All(t => IsMatch(t.s, t.g)))
                    yield return parentType;
            }
        
            static bool IsMatch(TypeReference selfArgument, TypeReference genericArgument)
            {
                if (selfArgument.IsGenericParameter || genericArgument.IsGenericParameter) return true;
                if (selfArgument.IsArray && genericArgument.IsArray) return IsMatch(selfArgument.GetElementType(), genericArgument.GetElementType());
                if (selfArgument.IsArray || genericArgument.IsArray) return false;
                if (!selfArgument.IsGenericType() && !genericArgument.IsGenericType()) return selfArgument.IsTypeEqual(genericArgument);
                if (!(selfArgument.IsGenericType() && genericArgument.IsGenericType())) return false;
                if (!selfArgument.Resolve().IsTypeEqual(genericArgument.Resolve())) return false;
                if (selfArgument.GetGenericParametersOrArgumentsCount() != genericArgument.GetGenericParametersOrArgumentsCount()) return false;
                return selfArgument.GetGenericParametersOrArguments()
                    .Zip(genericArgument.GetGenericParametersOrArguments(), (s, g) => (s, g))
                    .All(t => IsMatch(t.s, t.g))
                ;
            }
        }
    }
}