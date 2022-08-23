using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Unity.CompilationPipeline.Common.ILPostProcessing;

namespace AnyProcessor.CodeGen
{
    public class AnyProcessorPostProcessor : ILPostProcessor
    {
        private ILPostProcessorLogger _logger;
        
        public override ILPostProcessor GetInstance()
        {
            return this;
        }

        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            var thisAssemblyName = GetType().Assembly.GetName().Name;
            var runtimeAssemblyName = typeof(IAnyProcessorAttribute).Assembly.GetName().Name;
            return compiledAssembly.Name != thisAssemblyName &&
                   compiledAssembly.References.Any(f => Path.GetFileNameWithoutExtension(f) == runtimeAssemblyName);
        }

        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            using var resolver = new PostProcessorAssemblyResolver(compiledAssembly.References);
            using var assembly = compiledAssembly.LoadAssembly(resolver);
            _logger = assembly.CreateLogger();
            _logger.Info($"[AnyProcessor] processing: {assembly.Name.Name}({string.Join(",", compiledAssembly.References.Where(r => r.StartsWith("Library")))})");
            var modified = Process(compiledAssembly, assembly, resolver);
            if (!modified) return new ILPostProcessResult(null, _logger.Messages);
            
            var pe = new MemoryStream();
            var pdb = new MemoryStream();
            var writerParameters = new WriterParameters
            {
                SymbolWriterProvider = new PortablePdbWriterProvider(), SymbolStream = pdb, WriteSymbols = true
            };
            assembly.Write(pe, writerParameters);
            var inMemoryAssembly = new InMemoryAssembly(pe.ToArray(), pdb.ToArray());
            return new ILPostProcessResult(inMemoryAssembly, _logger.Messages);
        }

        private bool Process(ICompiledAssembly compiledAssembly, AssemblyDefinition assembly, PostProcessorAssemblyResolver resolver)
        {
            var module = assembly.MainModule;
            IReadOnlyList<AssemblyDefinition> referenceAssemblies = Array.Empty<AssemblyDefinition>();

            try
            {
                return ProcessProperties();
            }
            finally
            {
                foreach (var @ref in referenceAssemblies) @ref.Dispose();
            }

            bool ProcessProperties()
            {
                var typeTree = compiledAssembly.CreateTypeTree(resolver, assembly, _logger);
                var modified = false;
                var types = module.GetAllTypes();
                if (assembly.GetAttributesOf<ExplicityAnyProcessorTypeAttribute>().Any())
                    types = types.Where(type => type.GetAttributesOf<AnyProcessorTypeAttribute>().Any());
                
                foreach (var type in types)
                {
                    // Process(module, property, typeTree);
                    modified = true;
                }
                return modified;
            }
        }
        //
        // private void Process(ModuleDefinition module, PropertyDefinition property, TypeTree typeTree)
        // {
        //     if (property.GetMethod == null) throw new ArgumentException($"{property.Name}.get not exist");
        //     // TODO: search serialize
        //     var propertyType = CreatePropertyType();
        //     _logger.Info($"property type: {propertyType.FullName}");
        //     var fieldType = new DefaultTypeSearcher(typeTree, module).Search(propertyType);
        //     fieldType = module.ImportReference(fieldType);
        //     _logger.Info($"field type: {fieldType.FullName}");
        //     var serializedField = CreateOrReplaceBackingField(property, fieldType);
        //     _logger.Info($"serialize field type: {serializedField.FullName}");
        //     InjectGetter(property, serializedField);
        //     if (property.SetMethod != null) InjectSetter(property, serializedField);
        // }
    }
}