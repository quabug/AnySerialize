using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace AnySerialize.CodeGen
{
    public readonly ref struct TypeDef
    {
        [NotNull] public readonly TypeDefinition Type;
        [NotNull, ItemCanBeNull] public readonly Collection<TypeReference> GenericArguments;
        [NotNull, ItemNotNull] public readonly Collection<GenericParameter> GenericParameters;
        
        public bool IsGenericType => GenericParameters.Any();
        public bool IsPartialGenericType => GenericArguments.Any(argument => argument == null);
        
        public TypeDef([NotNull] TypeDefinition type)
            : this(type, type.GenericParameters)
        {}
        
        public TypeDef([NotNull] GenericInstanceType genericType)
            : this(genericType.Resolve(), genericType.GenericParameters, genericType.GenericArguments)
        {}
        
        public TypeDef([NotNull] TypeReference type)
            : this(
                type.Resolve(),
                type.IsGenericInstance ? ((GenericInstanceType)type).GenericParameters : new Collection<GenericParameter>(),
                type.IsGenericInstance ? ((GenericInstanceType)type).GenericArguments : new Collection<TypeReference>()
            )
        {}
        
        public TypeDef([NotNull] InterfaceImplementation @interface)
            : this(@interface.InterfaceType)
        {}
        
        public TypeDef([NotNull] TypeDefinition type, [NotNull, ItemNotNull] Collection<GenericParameter> genericParameters)
            : this(type, genericParameters, new Collection<TypeReference>(new TypeReference[genericParameters.Count]))
        {}
        
        public TypeDef(
            [NotNull] TypeDefinition type,
            [NotNull, ItemNotNull] Collection<GenericParameter> genericParameters,
            [NotNull, ItemCanBeNull] Collection<TypeReference> genericArguments
        )
        {
            Type = type;
            GenericParameters = genericParameters;
            GenericArguments = genericArguments;
        }

        public void Deconstruct(out TypeDefinition type, out Collection<GenericParameter> genericParameters, out Collection<TypeReference> genericArguments)
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