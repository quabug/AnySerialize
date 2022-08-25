using System;
using AnyProcessor;

namespace AnySerialize
{
    public interface IAnyTypeSearcherAttribute {}
    public interface IAnyGenericParameterSearcherAttribute : IAnyTypeSearcherAttribute {}
    public interface IAnyPropertySearcherAttribute : IAnyTypeSearcherAttribute {}
    public interface IAnyCodeGenAttribute : IAnyProcessorAttribute {}
    
    [AttributeUsage(AttributeTargets.Property)]
    public class AnySerializeAttribute : Attribute, IAnyPropertySearcherAttribute, IAnyCodeGenAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyConstraintTypeAttribute : Attribute, IAnyGenericParameterSearcherAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyFieldTypeAttribute : Attribute, IAnyGenericParameterSearcherAttribute {}
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }
}