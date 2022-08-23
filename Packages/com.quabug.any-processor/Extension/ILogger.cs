namespace AnyProcessor.CodeGen
{
    public interface ICodeGenLogger
    {
        void Error(string message);
        void Warning(string message);
        void Info(string message);
        void Debug(string message);
    }
}