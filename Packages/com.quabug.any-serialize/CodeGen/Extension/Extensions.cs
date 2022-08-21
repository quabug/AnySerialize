using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace AnySerialize.CodeGen
{
    internal static class CecilExtension
    {
        public static string ToReadableName(this TypeReference type)
        {
            if (!type.IsGenericInstance) return type.Name;
            return $"{type.Name.Split('`')[0]}<{string.Join(",", ((GenericInstanceType)type).GenericArguments.Select(a => a.Name))}>";
        }

        public static void AddEmptyCtor(this TypeDefinition type, MethodReference baseCtor)
        {
            //.method public hidebysig specialname rtspecialname instance void
            //  .ctor() cil managed
            //{
            //  .maxstack 8

            //  IL_0000: ldarg.0      // this
            //  IL_0001: call         instance void class [AnySerialize.Tests]AnySerialize.Tests.MultipleGeneric/Object`2<int32, float32>::.ctor()
            //  IL_0006: nop
            //  IL_0007: ret

            //} // end of method Object::.ctor
            var attributes = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var ctor = new MethodDefinition(".ctor", attributes, baseCtor.ReturnType);
            ctor.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
            ctor.Body.Instructions.Add(Instruction.Create(OpCodes.Call, baseCtor));
            ctor.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
            type.Methods.Add(ctor);
        }

        public static TypeReference CreateGenericTypeReference(this TypeDefinition type, params TypeReference[] genericArguments)
        {
            return type.HasGenericParameters
                ? (TypeReference) type.MakeGenericInstanceType(genericArguments)
                : type
            ;
        }
        
        public static MethodReference GetMethodReference(this TypeReference type, string methodName, ILPostProcessorLogger logger = null)
        {
            var method = type.Resolve().Methods.FirstOrDefault(method => method.Name == methodName);
            if (method == null) return null;
            var methodReference = type.Module.ImportReference(method);
            if (!type.IsGenericInstance) return methodReference;
            var parameters = ((GenericInstanceType)type).GenericArguments;
            logger?.Info($"{type.FullName}({type.HasGenericParameters}): {string.Join(",", parameters.Select(p => p.Name))}");
            return methodReference.CreateGenericMethodReference(parameters.ToArray(), logger);
        }
        
        public static MethodReference CreateGenericMethodReference(this MethodReference method, TypeReference[] genericArguments, ILPostProcessorLogger logger = null)
        {
            var reference = new MethodReference(method.Name, method.ReturnType) {
                DeclaringType = method.DeclaringType.MakeGenericInstanceType(genericArguments),
                HasThis = method.HasThis,
                ExplicitThis = method.ExplicitThis,
                CallingConvention = method.CallingConvention,
            };

            foreach (var parameter in method.Parameters)
                reference.Parameters.Add(new ParameterDefinition(parameter.ParameterType));

            foreach (var genericParameter in method.GenericParameters)
                reference.GenericParameters.Add(new GenericParameter(genericParameter.Name, reference));

            return reference;
        }

        public static string NameWithOuterClasses(this TypeDefinition type)
        {
            return type.GetSelfAndAllDeclaringTypes().Aggregate("", (name, t) => $"{t.Name}.{name}");
        }

        public static CustomAttribute AddCustomAttribute<T>(
            this ICustomAttributeProvider attributeProvider
            , ModuleDefinition module
            , params Type[] constructorTypes
        ) where T : Attribute
        {
            var attribute = new CustomAttribute(module.ImportReference(typeof(T).GetConstructor(constructorTypes)));
            attributeProvider.CustomAttributes.Add(attribute);
            return attribute;
        }

        public static TypeDefinition GenerateDerivedClass(this TypeReference baseType, IEnumerable<TypeReference> genericArguments, string className, ModuleDefinition module = null)
        {
            // .class nested public auto ansi beforefieldinit
            //   Object
            //     extends class [AnySerialize.Tests]AnySerialize.Tests.MultipleGeneric/Object`2<int32, float32>
            //     implements AnySerialize.Tests.TestMonoBehavior/IBase
            // {

            //   .method public hidebysig specialname rtspecialname instance void
            //     .ctor() cil managed
            //   {
            //     .maxstack 8

            //     IL_0000: ldarg.0      // this
            //     IL_0001: call         instance void class [AnySerialize.Tests]AnySerialize.Tests.MultipleGeneric/Object`2<int32, float32>::.ctor()
            //     IL_0006: nop
            //     IL_0007: ret

            //   } // end of method Object::.ctor
            // } // end of class Object
            module ??= baseType.Module;
            var classAttributes = TypeAttributes.Class | TypeAttributes.NestedPublic | TypeAttributes.BeforeFieldInit;
            var type = new TypeDefinition("", className, classAttributes);
            type.BaseType = baseType.HasGenericParameters ? baseType.MakeGenericInstanceType(genericArguments.ToArray()) : baseType;
            var ctor = module.ImportReference(baseType.Resolve().GetConstructors().First(c => !c.HasParameters)).Resolve();
            var ctorCall = new MethodReference(ctor.Name, module.ImportReference(ctor.ReturnType))
            {
                DeclaringType = type.BaseType,
                HasThis = ctor.HasThis,
                ExplicitThis = ctor.ExplicitThis,
                CallingConvention = ctor.CallingConvention,
            };
            type.AddEmptyCtor(ctorCall);
            return type;
        }

        public static TypeDefinition CreateNestedStaticPrivateClass(this TypeDefinition type, string name)
        {
            // .class nested private abstract sealed auto ansi beforefieldinit
            //   <$PropertyName>__generic_serialize_reference
            //     extends [mscorlib]System.Object
            var typeAttributes = TypeAttributes.Class |
                                 TypeAttributes.Sealed |
                                 TypeAttributes.Abstract |
                                 TypeAttributes.NestedPrivate |
                                 TypeAttributes.BeforeFieldInit;
            var nestedType = new TypeDefinition("", name, typeAttributes);
            nestedType.BaseType = type.Module.ImportReference(typeof(object));
            type.NestedTypes.Add(nestedType);
            return nestedType;
        }

        public static IEnumerable<CustomAttribute> GetAttributesOf<T>([NotNull] this ICustomAttributeProvider provider) where T : Attribute
        {
            return provider.HasCustomAttributes
                ? provider.CustomAttributes.Where(IsAttributeOf)
                : Enumerable.Empty<CustomAttribute>()
            ;
            static bool IsAttributeOf(CustomAttribute attribute) => attribute.AttributeType.FullName == typeof(T).FullName;
        }
    }
}