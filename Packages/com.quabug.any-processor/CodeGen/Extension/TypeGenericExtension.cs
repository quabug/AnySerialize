using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace AnyProcessor.CodeGen
{
    public static partial class Extension
    {
        [Pure]
        public static bool IsConcreteType(this TypeReference type)
        {
            return type switch
            {
                null => throw new ArgumentNullException(nameof(type)),
                GenericParameter => false,
                GenericInstanceType genericInstanceType => genericInstanceType.GenericArguments!.All(arg => arg.IsConcreteType()),
                TypeSpecification typeSpecification => typeSpecification.ElementType!.IsConcreteType(),
                _ => !type.HasGenericParameters
            };
        }

        [Pure]
        public static bool IsGenericType(this TypeReference type)
        {
            return type switch
            {
                null => throw new ArgumentNullException(nameof(type)),
                GenericParameter _ => true,
                GenericInstanceType _ => true,
                _ => type.HasGenericParameters
            };
        }
        
        // TODO: Covariant and contravariant?
        [Pure]
        public static bool IsPartialGenericTypeOf(this TypeReference partial, TypeReference generic)
        {
            if (partial == null) throw new ArgumentNullException(nameof(partial));
            if (generic == null) throw new ArgumentNullException(nameof(generic));
            if (partial.IsArray) throw new ArgumentException("not support array type", nameof(partial));
            if (generic.IsArray) throw new ArgumentException("not support array type", nameof(generic));
            
            if (partial.IsGenericParameter || generic.IsGenericParameter) return generic.IsGenericParameter;
            if (!partial.IsGenericType() && !generic.IsGenericType()) return partial.Resolve().TypeEquals(generic.Resolve());
            if (!partial.IsGenericType() || !generic.IsGenericType()) return false;
            var partialArguments = partial.GetGenericParametersOrArguments();
            var genericArguments = generic.GetGenericParametersOrArguments();
            return partial.Resolve().TypeEquals(generic.Resolve()) && 
                   partialArguments.Zip(genericArguments, (p, g) => (p, g)).All(t => t.p!.IsPartialGenericTypeOf(t.g!));
        }

        [Pure]
        public static IEnumerable<TypeReference> GetGenericParametersOrArguments(this TypeReference type)
        {
            if (type.IsGenericParameter) return type.Yield();
            if (type.HasGenericParameters) return type.GenericParameters!;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).GenericArguments;
            return Enumerable.Empty<TypeReference>();
        }
        
        [Pure]
        public static IEnumerable<GenericParameter> GetGenericParameters(this TypeReference type)
        {
            if (type.IsGenericParameter) return ((GenericParameter)type).Yield();
            if (type.HasGenericParameters) return type.GenericParameters!;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).ElementType.GenericParameters;
            return Enumerable.Empty<GenericParameter>();
        }
        
        public static void GetGenericParametersOrArguments(this TypeReference type, IList<TypeReference> arguments)
        {
            var i = 0;
            foreach (var arg in type.GetGenericParametersOrArguments())
            {
                arguments[i] = arg;
                i++;
            }
        }
        
        [Pure]
        public static int GetGenericParametersOrArgumentsCount(this TypeReference type)
        {
            if (type.HasGenericParameters) return type.GenericParameters!.Count;
            if (type.IsGenericInstance) return ((GenericInstanceType)type).GenericArguments.Count;
            return 0;
        }

        [Pure]
        public static bool IsMatchTypeConstraints(this TypeReference type)
        {
            if (type is not GenericInstanceType genericInstanceType) return true;
            return genericInstanceType.GenericArguments!
                .Zip(genericInstanceType.ElementType!.GenericParameters!, (argument, parameter) => (argument, parameter))
                .All(t => IsArgumentMatch(t.argument!, t.parameter!))
            ;
        
            static bool IsArgumentMatch(TypeReference genericArgument, GenericParameter genericParameter)
            {
                if (!genericParameter.HasConstraints) return true;
                if (genericArgument.IsGenericParameter) return true;
                return genericParameter.Constraints!
                    .Select(constraint => constraint.ConstraintType)
                    .All(genericArgument.IsDerivedFrom)
                ;
            }
        }

        // TODO: covariant/contravariant
        [Pure]
        public static bool IsDerivedFrom(this TypeReference derived, TypeReference @base)
        {
            if (derived.Resolve() == null) throw new ArgumentException("cannot resolve type", nameof(derived));
            if (@base.Resolve() == null) throw new ArgumentException("cannot resolve type", nameof(@base));
            if (derived is ArrayType derivedArray && @base is ArrayType baseArray)
                return derivedArray.ElementType.IsDerivedFrom(baseArray.ElementType);
            if (derived.IsArray || @base.IsArray) return false;
            if (!derived.Resolve()!.IsDerivedFrom(@base.Resolve()!)) return false;
            if (derived.GetGenericParametersOrArgumentsCount() != @base.GetGenericParametersOrArgumentsCount()) return false;
            return derived.GetGenericParametersOrArguments()
                .Zip(@base.GetGenericParametersOrArguments(), (d, b) => (d, b))
                .All(t => t.d.TypeEquals(t.b))
            ;
        }
        
        [Pure]
        public static bool IsDerivedFrom(this TypeDefinition derived, TypeDefinition @base)
        {
            return derived.GetAllBasesAndInterfaces().Any(type => type.Resolve().TypeEquals(@base));
        }

        public static bool IsImplementationOf(this TypeReference self, TypeReference generic)
        {
            return self.GetImplementationsOf(generic).Any();
        }
        
        public static IEnumerable<TypeReference> GetImplementationsOf(this TypeReference self, TypeReference @base)
        {
            if (self.Resolve() == null) throw new ArgumentException("cannot resolve type", nameof(self));
            if (@base.Resolve() == null) throw new ArgumentException("cannot resolve type", nameof(@base));
            
            var selfDef = self.Resolve();
            var genericDef = @base.Resolve();
            foreach (var parentType in selfDef!.GetBaseAndInterfaces())
            {
                if (!parentType.Resolve().TypeEquals(genericDef)) continue;
                if (!parentType.IsGenericType())
                    yield return parentType;
                else if (parentType.GetGenericParametersOrArguments().Zip(@base.GetGenericParametersOrArguments(), (s, g) => (s, g)).All(t => IsMatch(t.s!, t.g!)))
                    yield return parentType;
            }
        
            static bool IsMatch(TypeReference selfArgument, TypeReference genericArgument)
            {
                if (selfArgument.IsGenericParameter || genericArgument.IsGenericParameter) return true;
                if (selfArgument is ArrayType selfArray && genericArgument is ArrayType genericArray)
                    return IsMatch(selfArray.ElementType!, genericArray.ElementType!);
                if (selfArgument.IsArray || genericArgument.IsArray) return false;
                if (!selfArgument.IsGenericType() && !genericArgument.IsGenericType()) return selfArgument.TypeEquals(genericArgument);
                if (!(selfArgument.IsGenericType() && genericArgument.IsGenericType())) return false;
                if (!selfArgument.Resolve().TypeEquals(genericArgument.Resolve())) return false;
                if (selfArgument.GetGenericParametersOrArgumentsCount() != genericArgument.GetGenericParametersOrArgumentsCount()) return false;
                return selfArgument.GetGenericParametersOrArguments()
                    .Zip(genericArgument.GetGenericParametersOrArguments(), (s, g) => (s, g))
                    .All(t => IsMatch(t.s!, t.g!))
                ;
            }
        }
        
        [Pure]
        public static TypeReference FillGenericTypesByReferenceGenericIndex(this TypeReference self, TypeReference referenceGeneric)
        {
            if (!self.Resolve().TypeEquals(referenceGeneric.Resolve()))
                throw new ArgumentException($"{nameof(self)}({self.Resolve()}) and {nameof(referenceGeneric)}({referenceGeneric.Resolve()}) must have same type", nameof(self));
            
            if (self is ArrayType arrayType && referenceGeneric is ArrayType referenceArray)
            {
                var elementType = FillGenericTypesByReferenceGenericIndex(arrayType.ElementType!, referenceArray.ElementType!);
                return new ArrayType(elementType, arrayType.Rank);
            }
            if (!self.IsGenericType()) return self;

            if (referenceGeneric is not GenericInstanceType referenceGenericInstance)
                throw new ArgumentException( $"{nameof(referenceGeneric)}({referenceGeneric}) must be a {nameof(GenericInstanceType)}", nameof(referenceGeneric));
            
            // TODO: array pool on MacOS not working?
            //       (0,0): error System.TypeLoadException: Could not load type 'System.Buffers.ArrayPool`1' from assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
            // var genericArguments = ArrayPool<TypeReference>.Shared.Rent(self.GenericParameters.Count);
            var genericArguments = self.GetGenericParametersOrArguments().ToArray();
            for (var i = 0; i < genericArguments.Length; i++)
            {
                var arg = genericArguments[i];
                var refArg = referenceGenericInstance.GenericArguments![i]!;
                if (!refArg.IsGenericParameter) genericArguments[i] = arg.IsGenericParameter
                    ? refArg : FillGenericTypesByReferenceGenericIndex(arg, refArg)
                ;
            }
            return genericArguments.All(arg => arg.IsGenericParameter) ? self : self.MakeGenericInstanceType(genericArguments)!;
        }
        
        [Pure]
        public static TypeReference FillGenericTypesByReferenceGenericName(this TypeReference self, GenericInstanceType referenceGeneric)
        {
            return self.FillGenericTypesByReferenceGenericName(referenceGeneric.ElementType!.GenericParameters!, referenceGeneric.GenericArguments!);
        }
        
        [Pure]
        public static TypeReference FillGenericTypesByReferenceGenericName(
            this TypeReference self,
            IList<GenericParameter> referenceGenericParameters,
            IList<TypeReference> referenceGenericArguments
        )
        {
            if (referenceGenericArguments.Count != referenceGenericParameters.Count)
                throw new ArgumentException($"{nameof(referenceGenericParameters)}({referenceGenericParameters.Count}) and {nameof(referenceGenericArguments)}({referenceGenericArguments.Count}) must have same count", nameof(referenceGenericParameters));
            
            if (self is ArrayType arrayType)
            {
                var elementType = FillGenericTypesByReferenceGenericName(arrayType.ElementType!, referenceGenericParameters, referenceGenericArguments);
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
                    if (typeIndex < 0) throw new IndexOutOfRangeException($"cannot found generic parameter with name {arg.Name}");
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

        public static TypeReference CreateGenericInstanceType(this TypeReference self, IList<TypeReference> arguments)
        {
            if (self == null) throw new ArgumentNullException(nameof(self));
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));
            if (self.GetGenericParametersOrArgumentsCount() != arguments.Count)
                throw new ArgumentException($"the count of generic parameters({self.GetGenericParametersOrArgumentsCount()}) and arguments({arguments.Count}) are not match", nameof(self));
            
            if (arguments.Count == 0) return self;
            
            if (self.Resolve() == null) throw new ArgumentException("cannot resolve type", nameof(self));
            
            var genericInstanceType = new GenericInstanceType(self.Resolve()!);
            foreach (var arg in arguments) genericInstanceType.GenericArguments!.Add(arg);
            return genericInstanceType;
        }
    
        public static TypeReference FindGenericParameterType(this GenericParameter parameter, TypeReference baseType, TypeReference implementation)
        {
            if (!(baseType is GenericInstanceType genericBaseType)) return parameter;

            foreach (var (generic, index) in implementation.GetGenericParametersOrArguments().Select((generic, index) => (g: generic, index)))
            {
                if (generic.IsGenericParameter && generic.Name == parameter.Name)
                    return genericBaseType.GenericArguments![index]!;
                if (generic is ArrayType arrayGeneric && arrayGeneric.Name == $"{parameter.Name}[]")
                    return ((ArrayType)genericBaseType.GenericArguments![index]!).ElementType;
                
                if (generic is GenericInstanceType genericImplementation)
                {
                    var innerParameter = parameter.FindGenericParameterType(genericBaseType.GenericArguments![index]!, genericImplementation);
                    if (innerParameter != parameter) return innerParameter;
                    // continue searching
                }
            }
            return parameter;
        }
    }
}