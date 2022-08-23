using System;

namespace AnyProcessor
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class AnyProcessorTypeAttribute : Attribute {}
}