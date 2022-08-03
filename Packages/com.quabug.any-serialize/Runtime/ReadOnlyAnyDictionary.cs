using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    
    [Serializable]
    public class ReadOnlyAnyDictionary<TKey, TValue, TAnyKey, TAnyValue, TAnyPair> : IReadOnlyAny<Dictionary<TKey, TValue>>
        where TAnyPair : IReadOnlyAny<SerializeKeyValuePair<TKey, TValue, TAnyKey, TAnyValue>>
        where TAnyKey : IReadOnlyAny<TKey>
        where TAnyValue : IReadOnlyAny<TValue>
    {
        [SerializeField] private List<TAnyPair> _pairs;
        public Dictionary<TKey, TValue> Value => _pairs.ToDictionary(pair => pair.Value.Key.Value, pair => pair.Value.Value.Value);
    }
}