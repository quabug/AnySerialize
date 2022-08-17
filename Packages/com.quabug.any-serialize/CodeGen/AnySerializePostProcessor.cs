using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using UnityEngine;

namespace AnySerialize.CodeGen
{
    public class AnySerializePostProcessor : ILPostProcessor
    {
        private ILPostProcessorLogger _logger;
        
        public override ILPostProcessor GetInstance()
        {
            return this;
        }

        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            return false;
            var thisAssemblyName = GetType().Assembly.GetName().Name;
            var runtimeAssemblyName = typeof(AnySerializeAttribute).Assembly.GetName().Name;
            return compiledAssembly.Name != thisAssemblyName &&
                   compiledAssembly.References.Any(f => Path.GetFileNameWithoutExtension(f) == runtimeAssemblyName);
        }

        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            using var resolver = new PostProcessorAssemblyResolver(compiledAssembly.References);
            using var assembly = compiledAssembly.LoadAssembly(resolver);
            _logger = assembly.CreateLogger();
            _logger.Info($"process AnySerialize on {assembly.Name.Name}({string.Join(",", compiledAssembly.References.Where(r => r.StartsWith("Library")))})");
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
                foreach (var property in
                    from type in module.GetAllTypes()
                    where type.IsClass && !type.IsAbstract
                    from property in type.Properties.ToArray() // able to change `Properties` during looping
                    from attribute in property.GetAttributesOf<AnySerializeAttribute>()
                    where attribute != null
                    select property
                )
                {
                    if (property.GetMethod == null)
                    {
                        _logger.Error($"Cannot process on property {property.DeclaringType.FullName}.{property.Name} without getter");
                        continue;
                    }
                    GenerateField(module, property, typeTree);
                    modified = true;
                }
                return modified;
            }
        }

        private void GenerateField(ModuleDefinition module, PropertyDefinition property, TypeTree typeTree)
        {
            if (property.GetMethod == null) throw new ArgumentException($"{property.Name}.get not exist");
            // TODO: search serialize
            new DefaultTypeSearcher().Search(typeTree, property, _logger);
            var anySerializeValueType = module.ImportReference(typeof(IAny<>));
            var fieldType = module.ImportReference(anySerializeValueType.MakeGenericInstanceType(property.PropertyType));
            var serializedField = CreateOrReplaceBackingField(property, fieldType);
            InjectGetter(property, serializedField);
            if (property.SetMethod != null) InjectSetter(property, serializedField);
        }

        private string GetBackingFieldName(PropertyDefinition property)
        {
            return $"<{property.Name}>k__BackingField";
        }

        private FieldDefinition CreateOrReplaceBackingField(PropertyDefinition property, TypeReference fieldType)
        {
            var backingFieldName = GetBackingFieldName(property);
            var backingField = property.DeclaringType.Fields.FirstOrDefault(field => field.Name == backingFieldName)
                               ?? CreateSerializeReferenceField(property, fieldType);
            backingField.FieldType = fieldType;
            backingField.AddCustomAttribute<SerializeField>(property.Module);
            backingField.IsInitOnly = false;
            return backingField;
        }

        private FieldDefinition CreateSerializeReferenceField(
            PropertyDefinition property,
            TypeReference fieldType
        )
        {
            //.field private class AnySerialize.Tests.TestMonoBehavior/__generic_serialize_reference_GenericInterface__/IBase _GenericInterface
            //  .custom instance void [UnityEngine.CoreModule]UnityEngine.SerializeReference::.ctor()
            //    = (01 00 00 00 )
            var serializedField = new FieldDefinition(
                GetBackingFieldName(property)
                , FieldAttributes.Private
                , fieldType
            );
            property.DeclaringType.Fields.Add(serializedField);
            return serializedField;
        }

        private void InjectGetter(PropertyDefinition property, FieldDefinition serializedField)
        {
            // before
            //     IL_0000: ldarg.0      // this
            //     IL_0001: ldfld        int32 TestAnySerialize::'<Value>k__BackingField'
            //     IL_0006: ret
            
            // after
            //     IL_0000: ldarg.0      // this
            //     IL_0001: ldfld        class [AnySerialize]AnySerialize.AnyValue`1<object> TestAnySerialize::_value
            //     IL_0006: callvirt     instance !0/*object*/ class [AnySerialize]AnySerialize.AnyValue`1<object>::get_Value()
            //     IL_000b: ret
            var instructions = property.GetMethod.Body.Instructions;
            var getValueMethod = serializedField.FieldType.GetMethodReference("get_Value", _logger);
            instructions.Clear();
            instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
            instructions.Add(Instruction.Create(OpCodes.Ldfld, serializedField));
            instructions.Add(Instruction.Create(OpCodes.Callvirt, getValueMethod));
            instructions.Add(Instruction.Create(OpCodes.Ret));
        }

        private void InjectSetter(PropertyDefinition property, FieldDefinition serializedField)
        {
            // before
            //     IL_0000: ldarg.0      // this
            //     IL_0001: ldarg.1      // 'value'
            //     IL_0002: stfld        int32 TestAnySerialize::'<ntValue>k__BackingField'
            //     IL_0007: ret
            
            // after
            //     IL_0000: ldarg.0      // this
            //     IL_0001: ldfld        class [AnySerialize]AnySerialize.AnyValue`1<object> TestAnySerialize::_value
            //     IL_0006: ldarg.1      // 'value'
            //     IL_0007: callvirt     instance void class [AnySerialize]AnySerialize.AnyValue`1<object>::set_Value(!0/*object*/)
            //     IL_000d: ret
            var instructions = property.SetMethod.Body.Instructions;
            var setValueMethod = serializedField.FieldType.GetMethodReference("set_Value", _logger);
            instructions.Clear();
            instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
            instructions.Add(Instruction.Create(OpCodes.Ldfld, serializedField));
            instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
            instructions.Add(Instruction.Create(OpCodes.Callvirt, setValueMethod));
            instructions.Add(Instruction.Create(OpCodes.Ret));
        }

    }
}