using System;
using System.Collections.Generic;
using Unity.CompilationPipeline.Common.Diagnostics;

namespace AnySerialize.CodeGen
{
    public class ILPostProcessorLogger
    {
        public LogLevel LogLevel = LogLevel.Info;
        public readonly List<DiagnosticMessage> Messages;

        public ILPostProcessorLogger(List<DiagnosticMessage> messages = null)
        {
            Messages = messages;
        }

        public void Error(string message)
        {
            if (Messages == null) throw new ApplicationException(message);
            Messages.Add(new DiagnosticMessage {DiagnosticType = DiagnosticType.Error, MessageData = message});
        }

        public void Warning(string message)
        {
            if (LogLevel > LogLevel.Warning) return;
            if (Messages == null) Console.WriteLine("warning: " + message);
            else Messages.Add(new DiagnosticMessage {DiagnosticType = DiagnosticType.Warning, MessageData = message});
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