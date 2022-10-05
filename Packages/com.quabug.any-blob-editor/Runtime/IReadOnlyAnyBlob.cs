using Unity.Entities;

namespace Blob
{
    public interface IReadOnlyAnyBlob<T> where T : unmanaged
    {
        void Build(ref BlobBuilder builder, ref T data);
    }
}