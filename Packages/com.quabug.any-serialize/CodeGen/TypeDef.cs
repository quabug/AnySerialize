using System;
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
        public bool IsPartialGenericType => GenericArguments.Any(argument => argument.IsGenericParameter);
        
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
            for (var i = 0; i < lhs.GenericArguments.Count; i++) if (!lhs.GenericArguments[i].IsTypeEqual(rhs.GenericArguments[i])) return false;
            return true;
        }

        // TODO: test
        // TODO: Covariant and contravariant?
        public static bool IsPartialGenericTypeOf(this TypeDef partial, TypeDef generic)
        {
            return partial.Type.IsTypeEqual(generic.Type) && partial.GenericArguments.IsPartialGenericOf(generic.GenericArguments);
        }

        // TODO: test
        public static bool IsImplementationOf(this TypeDef self, TypeDef generic)
        {
            return self.GetImplementationsOf(generic).Any();
        }
        
        // TODO: test
        public static IEnumerable<TypeDef> GetImplementationsOf(this TypeDef self, TypeDef generic)
        {
            foreach (var selfBase in self.Type.Interfaces.Select(i => i.InterfaceType).Append(self.Type.BaseType))
                if (generic.IsPartialGenericTypeOf(selfBase)) yield return selfBase;
        }
    }
}