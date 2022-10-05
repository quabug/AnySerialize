using Unity.Entities;

namespace AnySerialize.Blob
{
    public interface IReadOnlyAnyBlob<T> where T : unmanaged
    {
        void Build(ref BlobBuilder builder, ref T data);
    }
}