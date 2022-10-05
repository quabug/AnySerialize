#if USE_UNITY_BLOB

using System;
using AnySerialize;
using Unity.Entities;
using UnityEngine;

namespace Blob
{
    [Serializable]
    public class AnyBlobPtr<T, [AnyConstraintType] TAny> : IReadOnlyAnyBlob<BlobPtr<T>>
        where T : unmanaged
        where TAny : IReadOnlyAnyBlob<T>
    {
        [SerializeField] private TAny _value;

        public void Build(ref BlobBuilder builder, ref BlobPtr<T> data)
        {
            ref var value = ref builder.Allocate(ref data);
            _value.Build(ref builder, ref value);
        }
    }
}

#endif