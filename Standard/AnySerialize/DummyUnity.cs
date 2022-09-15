using System;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SerializeFieldAttribute : Attribute {}
    
    [AttributeUsage(AttributeTargets.Field)]
    public class SerializeReferenceAttribute : Attribute {}
}