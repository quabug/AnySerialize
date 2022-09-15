using System;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using OneShot;

namespace AnySerialize.CodeGen
{
    public static class Extension
    {
        public static TypeReference? CreateConcreteTypeFrom(this Container container, TypeReference type)
        {
            var def = type.Resolve();
            if (def == null || def.IsAbstract || def.GetConstructors()!.FirstOrDefault(ctor => !ctor.HasParameters) == null) return null;
            if (type.IsConcreteType()) return type;
            
            if (type is not GenericInstanceType genericType)
                throw new ArgumentException($"{nameof(type)}({type}) must be a {nameof(GenericInstanceType)}", nameof(type));
            
            var anyGenericParameterSearcherAttributeType = type.Module!.ImportReference(typeof(IAnyGenericParameterSearcherAttribute))!;
                    
            for (var i = 0; i < genericType.GenericArguments!.Count; i++)
            {
                var arg = genericType.GenericArguments[i]!;
                if (arg is GenericParameter parameter)
                {
                    if (!parameter.HasCustomAttributes) return null;
                    var attribute = parameter.CustomAttributes!
                        .FirstOrDefault(attr => attr.AttributeType!.IsDerivedFrom(anyGenericParameterSearcherAttributeType))
                    ;
                    if (attribute == null) return null;
                    var genericArgument = container.Search(
                        attribute,
                        (parameter, typeof(GenericLabel<>)),
                        (genericType, typeof(GenericLabel<>))
                    );
                    if (genericArgument == null) return null;
                    genericType.GenericArguments[i] = genericArgument;
                }
                else if (!arg.IsConcreteType())
                {
                    throw new NotSupportedException();
                }
            }
            return genericType;
        }
        
        public static TypeReference CreateAnySerializePropertyType(this PropertyDefinition property, ILPostProcessorLogger? logger = null)
        {
            var isReadOnly = property.SetMethod == null;
            var baseType = isReadOnly ? typeof(IReadOnlyAny<>) : typeof(IAny<>);
            var baseTypeReference = property.Module.ImportReference(baseType);
            logger?.Info($"create property {baseTypeReference.FullName}<{string.Join(",", baseTypeReference.GenericParameters.Select(g => g.Name))}> {property.FullName}");
            return baseTypeReference.MakeGenericInstanceType(property.PropertyType);
        }
    }
}