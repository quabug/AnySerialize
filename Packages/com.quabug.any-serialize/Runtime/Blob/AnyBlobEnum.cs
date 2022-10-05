#if USE_UNITY_BLOB

using System;

namespace AnySerialize.Blob
{
    [Serializable]
    public class AnyBlobEnum<T> : AnyBlobValue<T> where T : unmanaged, Enum {}
}

#endif