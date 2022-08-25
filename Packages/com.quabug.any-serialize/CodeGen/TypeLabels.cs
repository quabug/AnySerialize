using OneShot;

namespace AnySerialize.CodeGen
{
    public interface OuterLabel<T> : ILabel<T> {}
    public interface TargetLabel<T> : ILabel<T> {}
    public interface GenericLabel<T> : ILabel<T> {}
}