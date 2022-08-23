using System;
using System.Collections.Generic;

namespace AnyProcessor.CodeGen
{
    public class ILPostProcessorLogger
    {
        public LogLevel LogLevel = LogLevel.Info;
        private readonly List<string> _warnings = new List<string>();
        private readonly List<string> _errors = new List<string>();
        public IReadOnlyList<string> Warnings => _warnings;
        public IReadOnlyList<string> Errors => _errors;

        public void Error(string message)
        {
            _errors.Add(message);
        }

        public void Warning(string message)
        {
            if (LogLevel > LogLevel.Warning) return;
            _warnings.Add(message);
        }

        public void Info(string message)
        {
            if (LogLevel > LogLevel.Info) return;
            Console.WriteLine("info: " + message);
        }

        public void Debug(string message)
        {
            if (LogLevel > LogLevel.Debug) return;
            Console.WriteLine("debug: " + message);
        }
    }
}