namespace AnySerialize.Tests
{
    public class AnotherAssembly
    {
        public interface IGeneric<T, U> {}
        public class Generic<T> : IGeneric<int, int> {}
        public class Generic : IGeneric<int, int> {}
    }
}