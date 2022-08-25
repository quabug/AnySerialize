using System;
using AnyProcessor;

namespace AnySerialize
{
    public abstract class AnySearcherAttribute : Attribute {}
    
    [AttributeUsage(AttributeTargets.Property)]
    public class AnySearcherSerializeAttribute : AnySearcherAttribute, IAnyProcessorAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnySearcherConstraintTypeAttribute : AnySearcherAttribute {}
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnySearcherFieldTypeAttribute : AnySearcherAttribute {}
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }
}