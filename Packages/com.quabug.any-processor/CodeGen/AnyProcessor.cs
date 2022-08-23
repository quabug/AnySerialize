using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace AnyProcessor.CodeGen
{
    public class AnyProcessor<T> where T : Attribute, IAnyProcessorAttribute
    {
        public ILPostProcessorLogger Logger { get; private set; }
        public PostProcessorAssemblyResolver Resolver { get; private set; }
        public AssemblyDefinition Assembly { get; private set; }
        public ModuleDefinition Module => Assembly.MainModule;
        public TypeDefinition AttributeType { get; private set; }
        public Lazy<TypeTree> TypeTree { get; private set; }

        public event Func<AssemblyDefinition, CustomAttribute, bool> ProcessAssembly;
        public event Func<ModuleDefinition, CustomAttribute, bool> ProcessModule;
        public event Func<TypeDefinition, CustomAttribute, bool> ProcessType;
        public event Func<MethodDefinition, CustomAttribute, bool> ProcessMethod;
        public event Func<PropertyDefinition, CustomAttribute, bool> ProcessProperty;
        public event Func<FieldDefinition, CustomAttribute, bool> ProcessField;
        public event Func<ParameterDefinition, CustomAttribute, bool> ProcessParameter;
        public event Func<GenericParameter, CustomAttribute, bool> ProcessGenericParameter;
        
        public bool WillProcess(Type thisType, string name, IEnumerable<string> references)
        {
            var thisAssemblyName = thisType.Assembly.GetName().Name;
            var runtimeAssemblyName = typeof(T).Assembly.GetName().Name;
            return name != thisAssemblyName && references.Any(f => Path.GetFileNameWithoutExtension(f) == runtimeAssemblyName);
        }

        public (byte[] pe, byte[] pdb) Process(byte[] pe, byte[] pdb, string[] references)
        {
            try
            {
                Resolver = new PostProcessorAssemblyResolver(references);
                Assembly = Resolver.LoadAssembly(pe, pdb);
                Logger = Assembly.CreateLogger();
                AttributeType = Module.ImportReference(typeof(T)).Resolve();
                TypeTree = new Lazy<TypeTree>(() => Resolver.CreateTypeTree(Assembly, references, Logger));
                Logger.Info($"[AnyProcessor] processing ({AttributeType}): {Assembly.Name.Name}({string.Join(",", references.Where(r => r.StartsWith("Library")))})");
                var modified = Process();
                if (!modified) return (null, null);

                var peStream = new MemoryStream();
                var pdbStream = new MemoryStream();
                var writerParameters = new WriterParameters
                {
                    SymbolWriterProvider = new PortablePdbWriterProvider(), SymbolStream = pdbStream, WriteSymbols = true
                };
                Assembly.Write(peStream, writerParameters);
                return (pdbStream.ToArray(), pdbStream.ToArray());
            }
            finally
            {
                Resolver?.Dispose();
                Assembly?.Dispose();
            }
        }

        private bool Process()
        {
            IReadOnlyList<AssemblyDefinition> referenceAssemblies = Array.Empty<AssemblyDefinition>();
            try
            {
                var modified = false;
                modified = ProcessEachAttribute(Assembly, ProcessAssembly) || modified;
                modified = ProcessEachAttribute(Module, ProcessModule) || modified;
                var explicitTypeProcessor = Assembly.GetAttributesOf<ExplicitAnyProcessorTypeAttribute>().Any();
                foreach (var type in Module.GetAllTypes())
                {
                    modified = ProcessEachAttribute(type, ProcessType) || modified;
                    if (type.HasGenericParameters) modified = ProcessEachAttribute(type.GenericParameters, ProcessGenericParameter) || modified;
                    if (explicitTypeProcessor && !type.GetAttributesOf<AnyProcessorTypeAttribute>().Any()) continue;

                    if (type.HasMethods) modified = ProcessEachAttribute(type.Methods, ProcessMethod) || modified;
                    if (type.HasProperties) modified = ProcessEachAttribute(type.Properties, ProcessProperty) || modified;
                    if (type.HasFields) modified = ProcessEachAttribute(type.Fields, ProcessField) || modified;
                }
                return modified;
            }
            finally
            {
                foreach (var @ref in referenceAssemblies) @ref.Dispose();
            }
        }

        private bool ProcessEachAttribute<TAttributeProvider>(TAttributeProvider value, Func<TAttributeProvider, CustomAttribute, bool> processor)
            where TAttributeProvider : ICustomAttributeProvider
        {
            if (processor == null) return false;

            var attributes = value.GetAttributesOf<T>();
            var modified = attributes.Aggregate(false, (current, attribute) => processor(value, attribute) || current);
            if (value is IGenericParameterProvider genericParameterProvider && genericParameterProvider.HasGenericParameters)
                modified = ProcessEachAttribute(genericParameterProvider.GenericParameters, ProcessGenericParameter) || modified;
            if (value is IMethodSignature methodSignature && methodSignature.HasParameters)
                modified = ProcessEachAttribute(methodSignature.Parameters, ProcessParameter) || modified;
            return modified;
        }
        
        private bool ProcessEachAttribute<TAttributeProvider>(IEnumerable<TAttributeProvider> values, Func<TAttributeProvider, CustomAttribute, bool> processor)
            where TAttributeProvider : ICustomAttributeProvider
        {
            return values.Aggregate(false, (current, value) => ProcessEachAttribute(value, processor) || current);
        }
    }
}