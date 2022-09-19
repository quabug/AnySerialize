# Any Processor
Easily write an ILPostProcessor with `AnyProcessor`

``` c#
public class WeavingAttribute : Attribute {}

[Weaving]
public class Foo
{
    [Weaving]
    public int Value;
}

public class WeavingPostProcessor : ILPostProcessor
{
    public override ILPostProcessor GetInstance()
    {
        return this;
    }
    
    public override bool WillProcess(ICompiledAssembly compiledAssembly)
    {
        return AnyProcessor<WeavingAttribute>.WillProcess(GetType(), compiledAssembly.Name, compiledAssembly.References);
    }

    public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
    {
        var assemblyMemory = compiledAssembly.InMemoryAssembly;
        using var processor = new AnyProcessor<WeavingAttribute>(assemblyMemory.PeData, assemblyMemory.PdbData, compiledAssembly.References);
        processor.ProcessType += OnProcessType;
        processor.ProcessField += OnProcessField;
        var (pe, pdb) = processor.Process();
        var warnings = processor.Logger.Warnings.Select(msg => new DiagnosticMessage { DiagnosticType = DiagnosticType.Warning, MessageData = msg });
        var errors = processor.Logger.Errors.Select(msg => new DiagnosticMessage { DiagnosticType = DiagnosticType.Error, MessageData = msg });
        var messages = warnings.Concat(errors).ToList();
        return pe == null ? new ILPostProcessResult(null, messages) : new ILPostProcessResult(new InMemoryAssembly(pe, pdb), messages);

        bool OnProcessType(TypeDefinition type, CustomAttribute attribute)
        {
            // weaving type with `WeavingAttribute`
            // here should be class `Foo`
        }
        
        bool OnProcessField(FieldDefinition field, CustomAttribute attribute)
        {
            // weaving field with `WeavingAttribute`
            // here should be field `Foo.Value`
        }
    }
}
```
