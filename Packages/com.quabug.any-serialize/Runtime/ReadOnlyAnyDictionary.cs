using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class SerializeKeyValuePair<TKey, TValue, TAnyKey, TAnyValue>
        where TAnyKey : IReadOnlyAny<TKey>
        where TAnyValue : IReadOnlyAny<TValue>
    {
        public TAnyKey Key;
        public TAnyValue Value;

        public void Deconstruct(out TKey key, out TValue value)
        {
            key = Key.Value;
            value = Value.Value;
        }
    }
    
    [Serializable]
    public class ReadOnlyAnyDictionary<TKey, TValue, TAnyKey, TAnyValue, TAnyPair> : IReadOnlyAny<Dictionary<TKey, TValue>>
        where TAnyPair : IReadOnlyAny<SerializeKeyValuePair<TKey, TValue, TAnyKey, TAnyValue>>
        where TAnyKey : IReadOnlyAny<TKey>
        where TAnyValue : IReadOnlyAny<TValue>
    {
        [SerializeField] private List<TAnyPair> _pairs;
        private readonly Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();
        public Dictionary<TKey, TValue> Value
        {
            get
            {
#if UNITY_EDITOR
                _cache.Clear();
#endif
                if (_cache.Count != _pairs.Count)
                {
                    foreach (var pair in _pairs)
                    {
                        var (key, value) = pair.Value;
                        _cache.Add(key, value);
                    }
                }
                return _cache;
            }
        }
    }
}