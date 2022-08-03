using System;

namespace AnySerialize
{
    public enum LogLevel
    {
        Debug, Info, Warning, Error
    }

    [AttributeUsage(AttributeTargets.Assembly)]
    public class AnySerializeLoggerAttribute : Attribute
    {
        public LogLevel LogLevel;
        public AnySerializeLoggerAttribute(LogLevel logLevel) => LogLevel = logLevel;
    }
}