using System;
using AnyProcessor;

namespace AnySerialize
{
    public abstract class AnySearcherAttribute : Attribute {}
    
    [AttributeUsage(AttributeTargets.Property)]
    public class AnySerializeAttribute : AnySearcherAttribute, IAnyProcessorAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyConstraintTypeAttribute : AnySearcherAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyFieldTypeAttribute : AnySearcherAttribute {}
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }
}