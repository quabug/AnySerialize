using System;
using AnyProcessor;

namespace AnySerialize
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AnySerializeAttribute : Attribute, IAnyProcessorAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyConstraintTypeAttribute : Attribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyFieldTypeAttribute : Attribute {}
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }
}