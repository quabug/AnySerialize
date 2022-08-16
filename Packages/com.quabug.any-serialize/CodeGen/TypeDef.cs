﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    public class TypeDef : IEquatable<TypeDef>
    {
        [NotNull] public TypeDefinition Type { get; }
        [NotNull, ItemNotNull] public IReadOnlyList<TypeReference> GenericArguments { get; }
        
        public bool IsGenericType => GenericArguments.Any();
        public bool IsConcreteType => !IsGenericType || GenericArguments.All(argument => argument.IsConcreteType());
        
        public TypeDef([NotNull] TypeDefinition type) : this(type, type.GenericParameters.Select(p => (TypeReference)p)) {}
        public TypeDef([NotNull] GenericInstanceType genericType) : this(genericType.Resolve(), genericType.GenericArguments) {}
        public TypeDef([NotNull] TypeReference type) : this(type.Resolve(), type.IsGenericInstance ? ((GenericInstanceType)type).GenericArguments : type.GenericParameters) {}
        public TypeDef([NotNull] InterfaceImplementation @interface) : this(@interface.InterfaceType) {}
        public TypeDef([NotNull] TypeDefinition type, [NotNull, ItemNotNull] IEnumerable<TypeReference> genericArguments)
        {
            Type = type;
            GenericArguments = genericArguments.ToArray();
        }

        public void Deconstruct(out TypeDefinition type, out IReadOnlyList<TypeReference> genericArguments)
        {
            type = Type;
            genericArguments = GenericArguments;
        }
        
        public static implicit operator TypeDef(TypeReference typeReference) => new TypeDef(typeReference);
        public static implicit operator TypeDef(TypeDefinition typeDefinition) => new TypeDef(typeDefinition);
        public static implicit operator TypeDef(InterfaceImplementation interfaceImplementation) => new TypeDef(interfaceImplementation);

        public static bool operator ==(TypeDef lhs, TypeDef rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return true;
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;
            return lhs.IsEqual(rhs);
        }

        public static bool operator !=(TypeDef lhs, TypeDef rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(TypeDef other)
        {
            return this.IsEqual(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TypeDef)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, GenericArguments);
        }

        public override string ToString()
        {
            var name = Type.FullName;
            if (GenericArguments.Any()) name += $"<{string.Join(",", GenericArguments.Select(arg => arg.FullName))}>";
            return name;
        }
    }

    public static class TypeDefExtension
    {
        public static bool IsEqual(this TypeDef lhs, TypeDef rhs)
        {
            if (ReferenceEquals(null, rhs)) return false;
            if (ReferenceEquals(lhs, rhs)) return true;
            if (!lhs.Type.IsTypeEqual(rhs.Type)) return false;
            if (lhs.GenericArguments.Count != rhs.GenericArguments.Count) return false;
            return !lhs.GenericArguments.Where((t, i) => !t.IsTypeEqual(rhs.GenericArguments[i])).Any();
        }

        // TODO: Covariant and contravariant?
        public static bool IsPartialGenericTypeOf(this TypeDef partial, TypeDef generic)
        {
            return partial.Type.IsTypeEqual(generic.Type) && partial.GenericArguments.IsPartialGenericOf(generic.GenericArguments);
        }

        public static bool IsImplementationOf(this TypeDef self, TypeDef generic)
        {
            return self.GetImplementationsOf(generic).Any();
        }
        
        public static IEnumerable<TypeDef> GetImplementationsOf(this TypeDef self, TypeDef generic)
        {
            foreach (var selfBase in self.Type.Interfaces.Select(i => i.InterfaceType).Append(self.Type.BaseType).Where(t => t != null))
            {
                if (!selfBase.Resolve().IsTypeEqual(generic.Type)) continue;
                if (!selfBase.IsGenericInstance)
                    yield return selfBase;
                else if (((GenericInstanceType)selfBase).GenericArguments.Zip(generic.GenericArguments, (s, g) => (s, g)).All(t => IsMatch(t.s, t.g)))
                    yield return selfBase;
            }
        
            static bool IsMatch(TypeReference selfArgument, TypeReference genericArgument)
            {
                if (selfArgument.IsGenericParameter || genericArgument.IsGenericParameter) return true;
                if (!selfArgument.IsGenericInstance && !genericArgument.IsGenericInstance) return selfArgument.Resolve().IsTypeEqual(genericArgument.Resolve());
                if (!(selfArgument.IsGenericInstance && genericArgument.IsGenericInstance)) return false;
                if (!selfArgument.Resolve().IsTypeEqual(genericArgument.Resolve())) return false;
                for (var i = 0; i < selfArgument.GenericParameters.Count; i++)
                {
                    var s = ((GenericInstanceType)selfArgument).GenericArguments[i];
                    var g = ((GenericInstanceType)genericArgument).GenericArguments[i];
                    if (!IsMatch(s, g)) return false;
                }
                return true;
            }
        }
    }
}