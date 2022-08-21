using Mono.Cecil;

namespace AnySerialize.CodeGen
{
    internal interface ITypeSearcher
    {
        TypeReference Search(TypeReference targetType);
    }
}