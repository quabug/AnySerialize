#if USE_UNITY_BLOB

using System;
using Unity.Entities;
using UnityEngine;

namespace AnySerialize.Blob
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyValuePriority)]
    public class AnyBlobValue<T> : IReadOnlyAnyBlob<T> where T : unmanaged
    {
        [SerializeField] private T _value;

        public void Build(ref BlobBuilder builder, ref T data)
        {
            data = _value;
        }
    }
}

#endif