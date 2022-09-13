using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnySerialize
{
    public class AnyKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }
    }
    
    [Serializable]
    public class ReadOnlyAnyDictionary<TKey, TValue, [AnyConstraintType] TAnyPair> : IReadOnlyAny<Dictionary<TKey, TValue>>
        where TAnyPair : IReadOnlyAny<AnyKeyValuePair<TKey, TValue>>
    {
        [SerializeField] private List<TAnyPair> _pairs;
        private Dictionary<TKey, TValue> _cache;
        public Dictionary<TKey, TValue> Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return _cache;
#endif
                _cache ??= new Dictionary<TKey, TValue>();
                foreach (var pair in _pairs) _cache.Add(pair.Value.Key, pair.Value.Value);
                return _cache;
            }
        }
    }
}