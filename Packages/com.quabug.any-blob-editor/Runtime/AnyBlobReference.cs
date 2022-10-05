using System;
using AnySerialize;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Blob
{
    [Serializable]
    public class AnyBlobReference<T, [AnyConstraintType] TAnyBlob> : IReadOnlyAny<BlobAssetReference<T>>
        where T : unmanaged
        where TAnyBlob : IReadOnlyAnyBlob<T>
    {
        [SerializeField] private TAnyBlob _blob = default!;
        private BlobAssetReference<T>? _cache;
        public BlobAssetReference<T> Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache.HasValue) return _cache.Value;
#endif
                var builder = new BlobBuilder(Allocator.Temp);
                try
                {
                    ref var root = ref builder.ConstructRoot<T>();
                    _blob.Build(ref builder, ref root);
                    _cache = builder.CreateBlobAssetReference<T>(Allocator.Persistent);
                    return _cache.Value;
                }
                finally
                {
                    builder.Dispose();
                }
            }
        }
    }
}