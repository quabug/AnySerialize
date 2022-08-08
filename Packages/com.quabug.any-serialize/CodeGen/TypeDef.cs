using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    public readonly ref struct TypeDef
    {
        public readonly TypeDefinition Type;
        public readonly IList<TypeReference> GenericTypes;
        
        public TypeDef(TypeDefinition type) : this(type, Enumerable.Empty<TypeReference>()) {}
        public TypeDef(GenericInstanceType genericType) : this(genericType.Resolve(), genericType.GenericArguments) {}
        public TypeDef(TypeDefinition type, IEnumerable<TypeReference> genericTypes)
        {
            Type = type;
            GenericTypes = genericTypes.ToArray();
        }

        public void Deconstruct(out TypeDefinition type, out IList<TypeReference> genericTypes)
        {
            type = Type;
            genericTypes = GenericTypes;
        }
    }

    public readonly ref struct GenericTypeWithParentIndices
    {
        public readonly TypeDef TypeDef;
        public readonly IReadOnlyList<int> Indices;

        public GenericTypeWithParentIndices(in TypeDef typeDef, IReadOnlyList<int> indices)
        {
            TypeDef = typeDef;
            Indices = indices;
        }
        
        public void Deconstruct(out TypeDefinition type, out IList<TypeReference> genericTypes, out IReadOnlyList<int> indices)
        {
            type = TypeDef.Type;
            genericTypes = TypeDef.GenericTypes;
            indices = Indices;
        }
    }
}