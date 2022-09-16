using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace AnyProcessor.CodeGen
{
    public static partial class Extension
    {
        public static readonly string BackingField = "k__BackingField";
        public static readonly int BackingFieldLength = BackingField.Length;
        public static readonly Regex BackingFieldRegex = new(@"<(\w+)>"+BackingField);
        
        [Pure]
        public static string ToReadableName(this Type type)
        {
            return type.IsGenericType ? Regex.Replace(type.ToString(), @"(\w+)`\d+\[(.*)\]", "$1<$2>") : type.ToString();
        }

        [Pure]
        public static IEnumerable<Type> GetSelfAndAllBases(this Type? type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }

        [Pure]
        public static Type ToReflectionType(this TypeReference cecilType)
        {
            return cecilType switch
            {
                TypeDefinition _ => Type.GetType(cecilType.FullName!.Replace('/', '+') + ", " + cecilType.Module.Assembly.FullName),
                GenericInstanceType genericType => genericType.Resolve().ToReflectionType().MakeGenericType(
                    genericType.Resolve().ToReflectionType().GetGenericArguments()
                        .Zip(genericType.GenericArguments.Select(arg => arg.IsGenericParameter ? null : arg.ToReflectionType()), (reflectionArg, cecilArg) => cecilArg ?? reflectionArg)
                        .ToArray()
                ),
                GenericParameter _ => throw new NotSupportedException(),
                ArrayType arrayType => arrayType.ElementType.ToReflectionType().MakeArrayType(/*arrayType.Rank*/), // array with rank become [*] which is not the same as array type in reflection.
                ByReferenceType byReferenceType => byReferenceType.ElementType.ToReflectionType().MakeByRefType(),
                PointerType pointerType => pointerType.ElementType.ToReflectionType().MakePointerType(),
                TypeSpecification _ => throw new NotSupportedException(),
                _ => cecilType.Resolve().ToReflectionType()
            };
        }

        [Pure]
        public static TypeReference ImportType(this ModuleDefinition module, Type type, ILPostProcessorLogger? logger = null)
        {
            if (type.IsArray) return module.ImportType(type.GetElementType()!, logger).MakeArrayType()!;
            if (type.IsByRef) return module.ImportType(type.GetElementType()!, logger).MakeByReferenceType()!;
            if (type.IsPointer) return module.ImportType(type.GetElementType()!, logger).MakePointerType()!;
            if (type.IsGenericParameter) throw new NotSupportedException();
            if (type.IsGenericType)
            {
                var genericTypeReference = module.ImportReference(type.GetGenericTypeDefinition()!)!;
                var genericTypeArguments = type.GetGenericArguments()
                    .Select(arg => arg.IsGenericParameter ? new GenericParameter(arg.Name, genericTypeReference) : module.ImportType(arg, logger))
                ;
                logger?.Debug($"[{nameof(ImportType)}] import generic type: {genericTypeReference}<{string.Join(",", genericTypeArguments.Select(a => a.Name))}>");
                return genericTypeReference.MakeGenericInstanceType(genericTypeArguments.ToArray());
            }
            return module.ImportReference(type)!;
        }
    }
}