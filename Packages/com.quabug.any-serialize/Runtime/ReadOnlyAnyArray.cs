using System;
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
#if !UNITY_EDITOR
                if (_cache.Length == _value.Length) return _cache;
#endif
                if (_cache.Length != _value.Length) _cache = new T[_value.Length];
                for (var i = 0; i < _cache.Length; i++) _cache[i] = _value[i].Value;
                return _cache;
            }
        }
    }
}