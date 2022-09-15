using System;
using AnyProcessor;

namespace AnySerialize
{
    public interface IAnyTypeSearcherAttribute {}
    public interface IAnyGenericParameterSearcherAttribute : IAnyTypeSearcherAttribute {}
    public interface IAnyPropertySearcherAttribute : IAnyTypeSearcherAttribute {}
    public interface IAnyCodeGenAttribute : IAnyProcessorAttribute {}

    [AttributeUsage(AttributeTargets.Property)]
    public class AnySerializeAttribute : Attribute, IAnyPropertySearcherAttribute, IAnyCodeGenAttribute
    {
        public Type? Base { get; }
        public AnySerializeAttribute(Type? @base = null) => Base = @base;
    }
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyConstraintTypeAttribute : Attribute, IAnyGenericParameterSearcherAttribute {}

    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyPropertyCodeGenOrConstraintTypeAttribute : Attribute, IAnyGenericParameterSearcherAttribute
    {
        public string GenericParameterName { get; }
        public AnyPropertyCodeGenOrConstraintTypeAttribute(string genericParameterName) => GenericParameterName = genericParameterName;
    }

    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyFieldTypeAttribute : Attribute, IAnyGenericParameterSearcherAttribute
    {
        public string GenericParameterName { get; }
        public AnyFieldTypeAttribute(string genericParameterName) => GenericParameterName = genericParameterName;
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class AnySerializePriorityAttribute : Attribute
    {
        public int Value { get; }
        public AnySerializePriorityAttribute(int value) => Value = value;
    }
}