using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace AnyProcessor.CodeGen
{
    internal static class PostProcessorExtension
    {
        public static AssemblyDefinition LoadAssembly(this IAssemblyResolver resolver, byte[] peData, byte[] pdbData)
        {
            var symbolStream = new MemoryStream(pdbData);
            var readerParameters = new ReaderParameters
            {
                SymbolStream = symbolStream,
                SymbolReaderProvider = new PortablePdbReaderProvider(),
                AssemblyResolver = resolver,
                ReflectionImporterProvider = new PostProcessorReflectionImporterProvider(),
                ReadingMode = ReadingMode.Immediate,
            };
            var peStream = new MemoryStream(peData);
            return AssemblyDefinition.ReadAssembly(peStream, readerParameters);
        }

        public static IEnumerable<AssemblyDefinition> LoadLibraryAssemblies(this PostProcessorAssemblyResolver resolver, IEnumerable<string> references)
        {
            return references.Where(name => name.StartsWith("Library")).Select(resolver.Resolve);
        }

        public static ILPostProcessorLogger CreateLogger(this AssemblyDefinition assembly)
        {
            var logger = new ILPostProcessorLogger();
            var loggerAttributes = assembly.GetAttributesOf<CodeGenLoggerAttribute>();
            if (loggerAttributes.Any()) logger.LogLevel = (LogLevel)loggerAttributes.First().ConstructorArguments[0].Value;
            return logger;
        }
        
        public static TypeTree CreateTypeTree(this PostProcessorAssemblyResolver resolver, AssemblyDefinition selfAssembly, IEnumerable<string> references, ILPostProcessorLogger? logger = null)
        {
            var referenceAssemblies = resolver.LoadLibraryAssemblies(references);
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