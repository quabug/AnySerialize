using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;

namespace AnyProcessor.CodeGen
{
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
            var loggerAttributes = assembly.GetAttributesOf<CodeGenLoggerAttribute>();
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
            return new TypeTree(allTypes) { Logger = logger };
        }
    }
}