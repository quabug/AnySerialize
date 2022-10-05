#if USE_UNITY_BLOB

using System;
using Unity.Entities;
using UnityEngine;

namespace AnySerialize.Blob
{
    [Serializable]
    public class AnyBlobGuid : IReadOnlyAnyBlob<Guid>
    {
        [SerializeField] private string _value = default!;

        public void Build(ref BlobBuilder builder, ref Guid data)
        {
            data = Guid.Parse(_value);
        }
    }
}

#endif