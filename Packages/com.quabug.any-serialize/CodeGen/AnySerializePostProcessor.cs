using System;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using UnityEngine;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    public class AnySerializePostProcessor : ILPostProcessor
    {
        private readonly AnyProcessor<AnySerializeAttribute> _processor = new AnyProcessor<AnySerializeAttribute>();

        public override ILPostProcessor GetInstance()
        {
            return this;
        }
        
        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            return _processor.WillProcess(GetType(), compiledAssembly.Name, compiledAssembly.References);
        }
    
        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            _processor.ProcessProperty += OnProcessProperty;
            var assemblyMemory = compiledAssembly.InMemoryAssembly;
            var (pe, pdb) = _processor.Process(assemblyMemory.PeData, assemblyMemory.PdbData, compiledAssembly.References);
            var warnings = _processor.Logger.Warnings.Select(msg => new DiagnosticMessage { DiagnosticType = DiagnosticType.Warning, MessageData = msg });
            var errors = _processor.Logger.Errors.Select(msg => new DiagnosticMessage { DiagnosticType = DiagnosticType.Error, MessageData = msg });
            var messages = warnings.Concat(errors).ToList();
            return pe == null ? new ILPostProcessResult(null, messages) : new ILPostProcessResult(new InMemoryAssembly(pe, pdb), messages);
        }

        private bool OnProcessProperty(PropertyDefinition propertyDefinition, CustomAttribute attribute)
        {
            if (propertyDefinition.GetMethod == null)
            {
                _processor.Logger.Error($"Cannot process on property {propertyDefinition.DeclaringType.FullName}.{propertyDefinition.Name} without getter");
                return false;
            }
            GenerateField(_processor.Module, propertyDefinition, _processor.TypeTree.Value);
            return true;
        }
        
        private void GenerateField(ModuleDefinition module, PropertyDefinition property, TypeTree typeTree)
        {
            var propertyType = CreatePropertyType();
            _processor.Logger.Info($"property type: {propertyType.FullName}");
            var fieldType = new DefaultTypeSearcher(typeTree, module).Search(propertyType);
            fieldType = module.ImportReference(fieldType);
            _processor.Logger.Info($"field type: {fieldType.FullName}");
            var serializedField = CreateOrReplaceBackingField(property, fieldType);
            _processor.Logger.Info($"serialize field type: {serializedField.FullName}");
            InjectGetter(property, serializedField);
            if (property.SetMethod != null) InjectSetter(property, serializedField);
        
            TypeReference CreatePropertyType()
            {
                var isReadOnly = property.SetMethod == null;
                var baseType = isReadOnly ? typeof(IReadOnlyAny<>) : typeof(IAny<>);
                Assert.IsTrue(typeof(IAny<>).IsAssignableFrom(baseType) || typeof(IReadOnlyAny<>).IsAssignableFrom(baseType));
                var baseTypeReference = module.ImportReference(baseType);
                _processor.Logger.Info($"create property {baseTypeReference.FullName}<{string.Join(",", baseTypeReference.GenericParameters.Select(g => g.Name))}> {property.FullName}");
                // TODO: only support base type with one and only one property type parameter?
                Assert.IsTrue(baseTypeReference.GenericParameters.Count == 1);
                return baseTypeReference.MakeGenericInstanceType(property.PropertyType);
            }
        }
        
        private FieldDefinition CreateOrReplaceBackingField(PropertyDefinition property, TypeReference fieldType)
        {
            var backingFieldName = property.GetBackingFieldName();
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
                property.GetBackingFieldName()
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
            var getValueMethod = serializedField.FieldType.GetMethodReference("get_Value", _processor.Logger);
            getValueMethod = property.Module.ImportReference(getValueMethod);
            _processor.Logger.Info($"getValueMethod: {getValueMethod?.FullName}");
            _processor.Logger.Info($"serialize field: {serializedField.FullName}");
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
            var setValueMethod = serializedField.FieldType.GetMethodReference("set_Value", _processor.Logger);
            setValueMethod = property.Module.ImportReference(setValueMethod);
            instructions.Clear();
            instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
            instructions.Add(Instruction.Create(OpCodes.Ldfld, serializedField));
            instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
            instructions.Add(Instruction.Create(OpCodes.Callvirt, setValueMethod));
            instructions.Add(Instruction.Create(OpCodes.Ret));
        }
    }
}