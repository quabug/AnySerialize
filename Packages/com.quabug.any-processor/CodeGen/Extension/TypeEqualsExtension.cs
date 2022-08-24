﻿using System;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnyProcessor.CodeGen
{
    public static class TypeEqualsExtension
    {
        [Pure]
        public static bool TypeEquals([NotNull] this TypeReference lhs, [NotNull] TypeReference rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            if (ReferenceEquals(lhs, rhs)) return true;
            return (lhs, rhs) switch
            {
                (GenericParameter l, GenericParameter r) => TypeEquals(l, r),
                (ArrayType l, ArrayType r) => TypeEquals(l, r),
                (ByReferenceType l, ArrayType r) => TypeEquals(l, r),
                (FunctionPointerType l, FunctionPointerType r) => TypeEquals(l, r),
                (GenericInstanceType l, GenericInstanceType r) => TypeEquals(l, r),
                (OptionalModifierType l, OptionalModifierType r) => TypeEquals(l, r),
                (PinnedType l, PinnedType r) => TypeEquals(l, r),
                (PointerType l, PointerType r) => TypeEquals(l, r),
                (RequiredModifierType l, RequiredModifierType r) => TypeEquals(l, r),
                (SentinelType l, SentinelType r) => TypeEquals(l, r),
                (TypeDefinition l, TypeDefinition r) => TypeEquals(l, r),
                (TypeSpecification _, TypeSpecification _) => throw new NotSupportedException(),
                _ => !lhs.IsGenericParameter && !rhs.IsGenericParameter
                     && !lhs.IsArray && !rhs.IsArray
                     && !lhs.IsByReference && !rhs.IsByReference
                     && !lhs.IsFunctionPointer && !rhs.IsFunctionPointer
                     && !lhs.IsOptionalModifier && !rhs.IsOptionalModifier
                     && !lhs.IsPinned && !rhs.IsPinned
                     && !lhs.IsPointer && !rhs.IsPointer
                     && !lhs.IsRequiredModifier && !rhs.IsRequiredModifier
                     && !lhs.IsSentinel && !rhs.IsSentinel
                     && lhs.GetGenericParametersOrArgumentsCount() == rhs.GetGenericParametersOrArgumentsCount()
                     && lhs.Resolve().TypeEquals(rhs.Resolve())
                     && (lhs.GetGenericParametersOrArgumentsCount() == 0 || lhs.GetGenericParametersOrArguments().Zip(rhs.GetGenericParametersOrArguments(), (l, r) => (l, r)).All(t => TypeEquals(t.l, t.r)))
            };
        }

        [Pure]
        public static bool TypeEquals([NotNull] this TypeDefinition lhs, [NotNull] TypeDefinition rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return lhs.MetadataToken == rhs.MetadataToken && lhs.Module.Name == rhs.Module.Name;
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this GenericParameter lhs, [NotNull] GenericParameter rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return lhs.IsContravariant == rhs.IsContravariant && lhs.IsCovariant == rhs.IsCovariant && lhs.IsNonVariant == rhs.IsNonVariant
                   && lhs.HasConstraints == rhs.HasConstraints && lhs.Constraints.Count == rhs.Constraints.Count
                   && lhs.Constraints.Zip(rhs.Constraints, (l, r) => (l, r)).All(t => TypeEquals(t.l, t.r));
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this GenericParameterConstraint lhs, [NotNull] GenericParameterConstraint rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return TypeEquals(lhs.ConstraintType, rhs.ConstraintType);
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this TypeSpecification lhs, [NotNull] TypeSpecification rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return TypeEquals(lhs.ElementType, rhs.ElementType);
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this GenericInstanceType lhs, [NotNull] GenericInstanceType rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            if (lhs.HasGenericArguments != rhs.HasGenericArguments) return false;
            if (lhs.GenericArguments.Count != rhs.GenericArguments.Count) return false;
            if (!TypeEquals(lhs.Resolve(), rhs.Resolve())) return false;
            return lhs.GenericArguments.Zip(rhs.GenericArguments, (l, r) => (l, r)).All(t => TypeEquals(t.l, t.r));
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this OptionalModifierType lhs, [NotNull] OptionalModifierType rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return TypeEquals(lhs.ModifierType, rhs.ModifierType) && TypeEquals(lhs.ElementType, rhs.ElementType);
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this RequiredModifierType lhs, [NotNull] RequiredModifierType rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return TypeEquals(lhs.ModifierType, rhs.ModifierType) && TypeEquals(lhs.ElementType, rhs.ElementType);
        }
        
        [Pure]
        public static bool TypeEquals([NotNull] this FunctionPointerType lhs, [NotNull] FunctionPointerType rhs)
        {
            throw new NotSupportedException();
        }
    }
}