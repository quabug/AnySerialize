using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    public readonly struct TypeDef
    {
        [NotNull] public readonly TypeDefinition Type;
        [NotNull, ItemCanBeNull] public readonly IReadOnlyList<TypeReference> GenericArguments;
        [NotNull, ItemNotNull] public readonly IReadOnlyList<GenericParameter> GenericParameters;
        
        public bool IsGenericType => GenericParameters.Any();
        public bool IsPartialGenericType => GenericArguments.Any(argument => argument == null);
        
        public TypeDef([NotNull] TypeDefinition type)
            : this(type, Enumerable.Empty<GenericParameter>())
        {}
        
        public TypeDef([NotNull] GenericInstanceType genericType)
            : this(genericType.Resolve(), genericType.GenericParameters, genericType.GenericArguments)
        {}
        
        public TypeDef([NotNull] TypeReference type)
            : this(
                type.Resolve(),
                type.IsGenericInstance ? ((GenericInstanceType)type).GenericParameters : Enumerable.Empty<GenericParameter>(),
                type.IsGenericInstance ? ((GenericInstanceType)type).GenericArguments : Enumerable.Empty<TypeReference>()
            )
        {}
        
        public TypeDef([NotNull] InterfaceImplementation @interface)
            : this(@interface.InterfaceType)
        {}
        
        public TypeDef([NotNull] TypeDefinition type, [NotNull, ItemNotNull] IEnumerable<GenericParameter> genericParameters)
            : this(type, genericParameters, genericParameters.Select(p => (TypeReference)null))
        {}
        
        public TypeDef(
            [NotNull] TypeDefinition type,
            [NotNull, ItemNotNull] IEnumerable<GenericParameter> genericParameters,
            [NotNull, ItemCanBeNull] IEnumerable<TypeReference> genericArguments
        )
        {
            Type = type;
            GenericParameters = genericParameters.ToArray();
            GenericArguments = genericArguments.ToArray();
        }

        public void Deconstruct(out TypeDefinition type, out IReadOnlyList<GenericParameter> genericParameters, out IReadOnlyList<TypeReference> genericArguments)
        {
            type = Type;
            genericParameters = GenericParameters;
            genericArguments = GenericArguments;
        }
        
        public static implicit operator TypeDef(TypeReference typeReference) => new TypeDef(typeReference);
        public static implicit operator TypeDef(TypeDefinition typeDefinition) => new TypeDef(typeDefinition);
        public static implicit operator TypeDef(InterfaceImplementation interfaceImplementation) => new TypeDef(interfaceImplementation);
    }
}