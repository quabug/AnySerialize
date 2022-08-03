namespace AnySerialize
{
    public interface IAny {}
    
    public interface IAny<T> : IAny
    {
        T Value { get; set; }
    }
    
    public interface IReadOnlyAny<out T> : IAny
    {
        T Value { get; }
    }
}