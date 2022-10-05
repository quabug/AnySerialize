#if USE_UNITY_BLOB

using System;
using Unity.Entities;
using UnityEngine;

namespace AnySerialize.Blob
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyArrayPriority)]
    public class AnyBlobArray<T, [AnyConstraintType] TAny> : IReadOnlyAnyBlob<BlobArray<T>>
        where T : unmanaged
        where TAny : IReadOnlyAnyBlob<T>
    {
        [SerializeField] private TAny[] _value = default!;
        
        public void Build(ref BlobBuilder builder, ref BlobArray<T> data)
        {
            var arrayBuilders = builder.Allocate(ref data, _value.Length);
            for (var i = 0; i < _value.Length; i++) _value[i].Build(ref builder, ref arrayBuilders[i]);
        }
    }
}

#endif