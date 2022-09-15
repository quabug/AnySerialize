using System.Linq;
using AnyProcessor.CodeGen;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using OneShot;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using UnityEngine;
using UnityEngine.Assertions;

namespace AnySerialize.CodeGen
{
    [UsedImplicitly]
    public class AnySerializePostProcessor : ILPostProcessor
    {
        public override ILPostProcessor GetInstance()
        {
            return this;
        }
        
        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            return AnyProcessor<IAnyCodeGenAttribute>.WillProcess(GetType(), compiledAssembly.Name, compiledAssembly.References);
        }
    
        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            var assemblyMemory = compiledAssembly.InMemoryAssembly;
            using var processor = new AnyProcessor<IAnyCodeGenAttribute>(assemblyMemory.PeData, assemblyMemory.PdbData, compiledAssembly.References);
            using var container = new Container();
            container.RegisterInstance(processor.Assembly).AsSelf();
            container.RegisterInstance(processor.Logger).AsSelf();
            container.RegisterInstance(processor.Module).AsSelf();
            container.RegisterInstance(processor.Resolver).AsSelf();
            container.RegisterInstance(processor.TypeTree.Value).AsSelf();
            processor.ProcessProperty += OnProcessProperty;
            var (pe, pdb) = processor.Process();
            var warnings = processor.Logger.Warnings.Select(msg => new DiagnosticMessage { DiagnosticType = DiagnosticType.Warning, MessageData = msg });
            var errors = processor.Logger.Errors.Select(msg => new DiagnosticMessage { DiagnosticType = DiagnosticType.Error, MessageData = msg });
            var messages = warnings.Concat(errors).ToList();
            return pe == null ? new ILPostProcessResult(null, messages) : new ILPostProcessResult(new InMemoryAssembly(pe, pdb), messages);

            bool OnProcessProperty(PropertyDefinition propertyDefinition, CustomAttribute attribute)
            {
                if (propertyDefinition.GetMethod == null)
                {
                    processor.Logger.Error($"Cannot process on property {propertyDefinition.DeclaringType.FullName}.{propertyDefinition.Name} without getter");
                    return false;
                }
                GenerateField(propertyDefinition, attribute);
                return true;
            }
            
            void GenerateField(PropertyDefinition property, CustomAttribute attribute)
            {
                var propertyType = property.CreateAnySerializePropertyType(processor.Logger);
                processor.Logger.Info($"property type: {propertyType}({string.Join(",", attribute.ConstructorArguments!.Select(a => a.Value))})");
                var fieldType = container.Search(
                    attribute,
                    (propertyType, typeof(TargetLabel<>))
                );
                processor.Logger.Debug($"field type: {fieldType}");
                fieldType = processor.Module.ImportReference(fieldType);
                var serializedField = property.CreateOrReplaceBackingField(fieldType);
                serializedField.AddCustomAttribute<SerializeField>(property.Module);
                processor.Logger.Info($"serialize field type: {serializedField.FullName}");
                property.ReplacePropertyGetterByFieldMethod(serializedField, "get_Value", processor.Logger);
                if (property.SetMethod != null) property.ReplacePropertySetterByFieldMethod(serializedField, "set_Value");
            }
        }
    }
}