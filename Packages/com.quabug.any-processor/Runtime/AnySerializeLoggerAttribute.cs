using System;

namespace AnyProcessor
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class CodeGenLoggerAttribute : Attribute
    {
        public LogLevel LogLevel;
        public CodeGenLoggerAttribute(LogLevel logLevel) => LogLevel = logLevel;
    }
}