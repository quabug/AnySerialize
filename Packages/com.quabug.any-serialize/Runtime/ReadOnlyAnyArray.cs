using System;
using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyArray<T, TAny> : IReadOnlyAny<T[]> where TAny : IReadOnlyAny<T>
    {
        [SerializeField] private TAny[] _value;
        private T[] _cache = Array.Empty<T>();
        public T[] Value
        {
            get
            {
                if (_cache.Length != _value.Length) _cache = _value.Select(v => v.Value).ToArray();
#if UNITY_EDITOR
                for (var i = 0; i < _cache.Length; i++) _cache[i] = _value[i].Value;
#endif
                return _cache;
            }
        }
    }
}