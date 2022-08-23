using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using UnityEngine.Assertions;

namespace AnyProcessor.CodeGen
{
    public static class TypeGenericExtension
    {
        [Pure]
        public static bool IsConcreteType([NotNull] this TypeReference type)
        {
            return type switch
            {
                null => throw new ArgumentNullException(),
                GenericParameter _ => false,
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
                GenericParameter _ => true,
                GenericInstanceType _ => true,
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
            if (type.IsGenericParameter) return type.Yield();
            if (type.HasGenericParameters) return type.GenericParameters;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).GenericArguments;
            return Enumerable.Empty<TypeReference>();
        }
        
        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<GenericParameter> GetGenericParameters([NotNull] this TypeReference type)
        {
            if (type.IsGenericParameter) return ((GenericParameter)type).Yield();
            if (type.HasGenericParameters) return type.GenericParameters;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).ElementType.GenericParameters;
            return Enumerable.Empty<GenericParameter>();
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
            if (!(type is GenericInstanceType genericInstanceType)) return true;
            return genericInstanceType.GenericArguments
                .Zip(genericInstanceType.ElementType.GenericParameters, (argument, parameter) => (argument, parameter))
                .All(t => IsArgumentMatch(t.argument, t.parameter))
            ;
        
            static bool IsArgumentMatch(TypeReference genericArgument, GenericParameter genericParameter)
            {
                if (!genericParameter.HasConstraints) return true;
                if (genericArgument.IsGenericParameter) return true;
                return genericParameter.Constraints
                    .Select(constraint => constraint.ConstraintType)
                    .All(genericArgument.IsDerivedFrom)
                ;
            }
        }

        // TODO: covariant/contravariant
        [Pure]
        public static bool IsDerivedFrom([NotNull] this TypeReference derived, [NotNull] TypeReference @base)
        {
            if (!derived.Resolve().IsDerivedFrom(@base.Resolve())) return false;
            if (derived.GetGenericParametersOrArgumentsCount() != @base.GetGenericParametersOrArgumentsCount()) return false;
            return derived.GetGenericParametersOrArguments()
                .Zip(@base.GetGenericParametersOrArguments(), (d, b) => (d, b))
                .All(t => t.d.IsTypeEqual(t.b))
            ;
        }
        
        [Pure]
        public static bool IsDerivedFrom([NotNull] this TypeDefinition derived, [NotNull] TypeDefinition @base)
        {
            return derived.GetAllBasesAndInterfaces().Any(type => type.Resolve().IsTypeEqual(@base));
        }

        public static bool IsImplementationOf(this TypeReference self, TypeReference generic)
        {
            return self.GetImplementationsOf(generic).Any();
        }
        
        public static IEnumerable<TypeReference> GetImplementationsOf(this TypeReference self, TypeReference @base)
        {
            var selfDef = self.Resolve();
            var genericDef = @base.Resolve();
            foreach (var parentType in selfDef.GetBaseAndInterfaces())
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
        
        [Pure, NotNull]
        public static TypeReference FillGenericTypesByReferenceGenericIndex([NotNull] this TypeReference self, [NotNull] TypeReference referenceGeneric)
        {
            Assert.AreEqual(self.Resolve(), referenceGeneric.Resolve());
            
            if (self is ArrayType arrayType && referenceGeneric is ArrayType referenceArray)
            {
                var elementType = FillGenericTypesByReferenceGenericIndex(arrayType.ElementType, referenceArray.ElementType);
                return new ArrayType(elementType, arrayType.Rank);
            }
            if (!self.IsGenericType()) return self;
            
            Assert.IsTrue(referenceGeneric.IsGenericInstance);

            var referenceGenericInstance = (GenericInstanceType)referenceGeneric;
            
            // TODO: array pool on MacOS not working?
            //       (0,0): error System.TypeLoadException: Could not load type 'System.Buffers.ArrayPool`1' from assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
            // var genericArguments = ArrayPool<TypeReference>.Shared.Rent(self.GenericParameters.Count);
            var genericArguments = self.GetGenericParametersOrArguments().ToArray();
            for (var i = 0; i < genericArguments.Length; i++)
            {
                var arg = genericArguments[i];
                var refArg = referenceGenericInstance.GenericArguments[i];
                if (!refArg.IsGenericParameter) genericArguments[i] = arg.IsGenericParameter
                    ? refArg : FillGenericTypesByReferenceGenericIndex(arg, refArg)
                ;
            }
            return genericArguments.All(arg => arg.IsGenericParameter) ? self : self.MakeGenericInstanceType(genericArguments);
        }
        
        [Pure, NotNull]
        public static TypeReference FillGenericTypesByReferenceGenericName([NotNull] this TypeReference self, [NotNull] GenericInstanceType referenceGeneric)
        {
            return self.FillGenericTypesByReferenceGenericName(referenceGeneric.ElementType.GenericParameters, referenceGeneric.GenericArguments);
        }
        
        [Pure, NotNull]
        public static TypeReference FillGenericTypesByReferenceGenericName(
            [NotNull] this TypeReference self,
            [NotNull, ItemNotNull] IList<GenericParameter> referenceGenericParameters,
            [NotNull, ItemNotNull] IList<TypeReference> referenceGenericArguments
        )
        {
            Assert.AreEqual(referenceGenericArguments.Count, referenceGenericParameters.Count);
            
            if (self is ArrayType arrayType)
            {
                var elementType = FillGenericTypesByReferenceGenericName(arrayType.ElementType, referenceGenericParameters, referenceGenericArguments);
                return new ArrayType(elementType, arrayType.Rank);
            }
            if (!self.IsGenericType()) return self;
            
            // TODO: array pool on MacOS not working?
            //       (0,0): error System.TypeLoadException: Could not load type 'System.Buffers.ArrayPool`1' from assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
            // var genericArguments = ArrayPool<TypeReference>.Shared.Rent(self.GenericParameters.Count);
            var genericArguments = self.GetGenericParametersOrArguments().ToArray();
            for (var i = 0; i < genericArguments.Length; i++)
            {
                var arg = genericArguments[i];
                if (arg.IsGenericParameter)
                {
                    var typeIndex = referenceGenericParameters.FindIndexOf(t =>  t.IsGenericParameter && t.Name == arg.Name);
                    Assert.IsTrue(typeIndex >= 0);
                    genericArguments[i] = referenceGenericArguments[typeIndex];
                }
                else
                {
                    genericArguments[i] = FillGenericTypesByReferenceGenericName(arg, referenceGenericParameters, referenceGenericArguments);
                }
            }
            if (self.IsGenericParameter) return genericArguments.First();
            return self.CreateGenericInstanceType(genericArguments);
        }

        public static TypeReference CreateGenericInstanceType([NotNull] this TypeReference self, [NotNull, ItemNotNull] IList<TypeReference> arguments)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (arguments == null)
                throw new ArgumentNullException(nameof(arguments));
            if (self.GetGenericParametersOrArgumentsCount() != arguments.Count)
                throw new ArgumentException();
            
            if (arguments.Count == 0) return self;
            
            var genericInstanceType = new GenericInstanceType(self.Resolve());
            foreach (var (@new, old) in arguments.Zip(self.GetGenericParametersOrArguments(), (@new, old) => (@new, old)))
                genericInstanceType.GenericArguments.Add(old.IsGenericParameter ? @new : old);
            return genericInstanceType;
        }
    }
}