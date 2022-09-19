using System.Linq;
using AnyProcessor.CodeGen;
using JetBrains.Annotations;
using Mono.Cecil;
using OneShot;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using UnityEngine;

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

            var unityObjectDefinition = processor.Module.ImportReference(typeof(UnityEngine.Object)).Resolve();
            
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

                if (!propertyDefinition.DeclaringType.IsDerivedFrom(unityObjectDefinition))
                {
                    processor.Logger.Info("this processor will only running on properties of type derived from UnityEngine.Object");
                    return false;
                }
                
                return GenerateField(propertyDefinition, attribute);
            }
            
            bool GenerateField(PropertyDefinition property, CustomAttribute attribute)
            {
                var fieldType = container.Search(
                    attribute,
                    (property, typeof(TargetLabel<>))
                );
                if (fieldType == null)
                {
                    processor.Logger.Warning($"cannot find proper type of {property}:{property.PropertyType}");
                    return false;
                }
                
                processor.Logger.Debug($"field type: {fieldType}");
                fieldType = processor.Module.ImportReference(fieldType);
                var serializedField = property.CreateOrReplaceBackingField(fieldType);
                serializedField.AddCustomAttribute<SerializeField>(property.Module);
                processor.Logger.Info($"serialize field type: {serializedField.FullName}");
                property.ReplacePropertyGetterByFieldMethod(serializedField, "get_Value", processor.Logger);
                if (property.SetMethod != null) property.ReplacePropertySetterByFieldMethod(serializedField, "set_Value");
                return true;
            }
        }
    }
}