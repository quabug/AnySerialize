using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Mono.Collections.Generic;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    internal static class EnumerableExtension
    {
        public static IEnumerable<T> Yield<T>(this T value)
        {
            yield return value;
        }

        public static int FindLastIndexOf<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (predicate(list[i]))
                    return i;
            }
            return -1;
        }
        
        public static int FindIndexOf<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                    return i;
            }
            return -1;
        }
    }

    internal static class ReflectionExtension
    {
        public static string ToReadableName(this Type type)
        {
            return type.IsGenericType ? Regex.Replace(type.ToString(), @"(\w+)`\d+\[(.*)\]", "$1<$2>") : type.ToString();
        }
    }

    internal static class PostProcessorExtension
    {
        public static AssemblyDefinition LoadAssembly(this ICompiledAssembly compiledAssembly, IAssemblyResolver resolver)
        {
            var symbolStream = new MemoryStream(compiledAssembly.InMemoryAssembly.PdbData.ToArray());
            var readerParameters = new ReaderParameters
            {
                SymbolStream = symbolStream,
                SymbolReaderProvider = new PortablePdbReaderProvider(),
                AssemblyResolver = resolver,
                ReflectionImporterProvider = new PostProcessorReflectionImporterProvider(),
                ReadingMode = ReadingMode.Immediate,
            };
            var peStream = new MemoryStream(compiledAssembly.InMemoryAssembly.PeData.ToArray());
            return AssemblyDefinition.ReadAssembly(peStream, readerParameters);
        }

        public static IEnumerable<AssemblyDefinition> LoadLibraryAssemblies(this ICompiledAssembly compiledAssembly, PostProcessorAssemblyResolver resolver)
        {
            return compiledAssembly.References.Where(name => name.StartsWith("Library")).Select(resolver.Resolve);
        }

        public static ILPostProcessorLogger CreateLogger(this AssemblyDefinition assembly)
        {
            var logger = new ILPostProcessorLogger(new List<DiagnosticMessage>());
            var loggerAttributes = assembly.GetAttributesOf<AnySerializeLoggerAttribute>();
            if (loggerAttributes.Any()) logger.LogLevel = (LogLevel)loggerAttributes.First().ConstructorArguments[0].Value;
            return logger;
        }
        
        public static TypeTree CreateTypeTree(this ICompiledAssembly compiledAssembly, PostProcessorAssemblyResolver resolver, AssemblyDefinition selfAssembly, ILPostProcessorLogger logger = null)
        {
            var referenceAssemblies = compiledAssembly.LoadLibraryAssemblies(resolver);
            var allTypes = referenceAssemblies.Append(selfAssembly)
                .Where(asm => !asm.Name.Name.StartsWith("Unity.")
                              && !asm.Name.Name.StartsWith("UnityEditor.")
                              && !asm.Name.Name.StartsWith("UnityEngine.")
                )
                .SelectMany(asm => asm.MainModule.GetAllTypes())
            ;
            return new TypeTree(allTypes, logger);
        }
    }

    internal static class CecilExtension
    {
        public static string ToReadableName(this TypeReference type)
        {
            if (!type.IsGenericInstance) return type.Name;
            return $"{type.Name.Split('`')[0]}<{string.Join(",", ((GenericInstanceType)type).GenericArguments.Select(a => a.Name))}>";
        }
        
        public static IEnumerable<TypeReference> ParentTypes(this TypeDefinition type)
        {
            var parents = Enumerable.Empty<TypeReference>();
            if (type.HasInterfaces) parents = type.Interfaces.Select(i => i.InterfaceType);
            if (type.BaseType != null) parents = parents.Append(type.BaseType);
            return parents;
        }

        public static bool IsPartialGenericMatch(this GenericInstanceType partial, GenericInstanceType concrete)
        {
            if (!IsTypeEqual(partial.Resolve(), concrete.Resolve()))
                throw new ArgumentException($"{partial} and {concrete} have different type");
            return IsPartialGenericMatch(partial.GenericArguments, concrete.GenericArguments);
        }
        
        public static bool IsPartialGenericMatch(this IList<TypeReference> partial, IList<TypeReference> concrete)
        {
            if (partial.Count != concrete.Count)
                throw new ArgumentException($"{partial} and {concrete} have different count of generic arguments");
            if (concrete.Any(arg => arg.IsGenericParameter))
                throw new ArgumentException($"{concrete} is not a concrete generic type");

            return partial
                .Zip(concrete, (partialArgument, concreteArgument) => (partialArgument, concreteArgument))
                .All(t => t.partialArgument.IsGenericParameter || IsTypeEqual(t.partialArgument, t.concreteArgument))
            ;
        }
        
        public static bool IsPartialGenericOf(
            [NotNull, ItemNotNull] this IReadOnlyList<TypeReference> partial,
            [NotNull, ItemNotNull] IReadOnlyList<TypeReference> generic
        )
        {
            if (partial.Count != generic.Count)
                throw new ArgumentException("partial and generic have different count of generic arguments"); ;

            for (var i = 0; i < partial.Count; i++)
            {
                var partialArgument = partial[i];
                var genericArgument = generic[i];
                if (!genericArgument.IsGenericParameter && !IsTypeEqual(genericArgument, partialArgument)) return false;
            }
            return true;
        }

        public static bool IsTypeEqual(this TypeReference lhs, TypeReference rhs)
        {
            if (lhs.IsGenericParameter && rhs.IsGenericParameter) return true;
            if (lhs.IsGenericParameter || rhs.IsGenericParameter) return false;
            if (lhs.IsGenericInstance && rhs.IsGenericInstance)
                return lhs.GenericParameters.Count == rhs.GenericParameters.Count && IsTypeEqual((GenericInstanceType)lhs, (GenericInstanceType)rhs);
            if (!lhs.IsArray && !rhs.IsArray) return IsTypeEqual(lhs.Resolve(), rhs.Resolve());
            if (lhs.IsArray || rhs.IsArray) return false;
            return IsTypeEqual(lhs.GetElementType(), rhs.GetElementType());
        }

        public static bool IsTypeEqual(this TypeDefinition lhs, TypeDefinition rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            return lhs.MetadataToken == rhs.MetadataToken && lhs.Module.Name == rhs.Module.Name;
        }
        
        public static bool IsTypeEqual(this GenericInstanceType lhs, GenericInstanceType rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            if (lhs.GenericArguments.Count != rhs.GenericArguments.Count) return false;
            if (!IsTypeEqual(lhs.Resolve(), rhs.Resolve())) return false;
            return !lhs.GenericArguments.Where((t, i) => !t.IsTypeEqual(rhs.GenericArguments[i])).Any();
        }

        public static bool IsConcreteType([NotNull] this TypeReference type)
        {
            if (type == null) throw new ArgumentNullException();
            if (type.IsGenericParameter) return false;
            if (!type.IsGenericInstance) return true;
            return ((GenericInstanceType)type).IsConcreteType();
        }

        public static bool IsConcreteType([NotNull] this GenericInstanceType type)
        {
            if (type == null) throw new ArgumentNullException();
            return type.GenericArguments.All(arg => arg.IsConcreteType());
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

        public static bool IsPublicOrNestedPublic(this TypeDefinition type)
        {
            foreach (var t in type.GetSelfAndAllDeclaringTypes())
            {
                if ((t.IsNested && !t.IsNestedPublic) || (!t.IsNested && !t.IsPublic)) return false;
            }
            return true;
        }

        public static string NameWithOuterClasses(this TypeDefinition type)
        {
            return type.GetSelfAndAllDeclaringTypes().Aggregate("", (name, t) => $"{t.Name}.{name}");
        }

        public static IEnumerable<TypeDefinition> GetSelfAndAllDeclaringTypes(this TypeDefinition type)
        {
            yield return type;
            while (type.DeclaringType != null)
            {
                yield return type.DeclaringType;
                type = type.DeclaringType;
            }
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
            return provider.HasCustomAttributes ?
                provider.CustomAttributes.Where(IsAttributeOf) :
                Enumerable.Empty<CustomAttribute>();

            static bool IsAttributeOf(CustomAttribute attribute) => attribute.AttributeType.FullName == typeof(T).FullName;
        }
    }
}