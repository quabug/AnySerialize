#if USE_UNITY_BLOB

using System;
using Unity.Entities;
using UnityEngine;

namespace AnySerialize.Blob
{
    [Serializable]
    public class AnyBlobString : IReadOnlyAnyBlob<BlobString>
    {
        [SerializeField] private string _value = default!;

        public void Build(ref BlobBuilder builder, ref BlobString data)
        {
            builder.AllocateString(ref data, _value);
        }
    }
}

#endif