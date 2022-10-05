#if USE_UNITY_BLOB

using System;
using Unity.Entities;
using UnityEngine;

namespace Blob
{
    [Serializable]
    public class AnyBlobString : IReadOnlyAnyBlob<BlobString>
    {
        [SerializeField] private string _value;

        public void Build(ref BlobBuilder builder, ref BlobString data)
        {
            builder.AllocateString(ref data, _value);
        }
    }
}

#endif