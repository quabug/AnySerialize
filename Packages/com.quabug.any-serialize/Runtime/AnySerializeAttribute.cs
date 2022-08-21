using System;

namespace AnySerialize
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AnySerializeAttribute : Attribute
    {
        public const int SearchingBaseTypeIndex = 0;
        public AnySerializeAttribute(Type searchingBaseType = null) {}
    }
    
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class AnyGenericAttribute : Attribute
    {
        public AnyGenericAttribute(Type anySerializeBaseType) {}
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AnySerializeFieldOrderAttribute : Attribute
    {
        public int Order { get; }
        public AnySerializeFieldOrderAttribute(int order) => Order = order;
    }
}