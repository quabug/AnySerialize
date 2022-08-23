using System;
using AnyProcessor;

namespace AnySerialize
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AnySerializeAttribute : Attribute, IAnyProcessorAttribute
    {
        public Type Searcher { get; set; }
        public Type BaseType { get; set; }
    }
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyGenericAttribute : Attribute
    {
        public Type Searcher { get; set; }
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }
}