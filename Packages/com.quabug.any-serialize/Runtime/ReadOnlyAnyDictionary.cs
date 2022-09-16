using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnySerialize
{
    [AnySerializable]
    public class AnyKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; } = default!;
        public TValue Value { get; } = default!;
    }
    
    [Serializable]
    public class ReadOnlyAnyDictionary<TKey, TValue, [AnyConstraintType] TAnyPair> : IReadOnlyAny<Dictionary<TKey, TValue>>, IReadOnlyAny<IDictionary<TKey, TValue>>, IReadOnlyAny<IReadOnlyDictionary<TKey, TValue>>
        where TAnyPair : IReadOnlyAnyClass<AnyKeyValuePair<TKey, TValue>>
    {
        [SerializeField] private List<TAnyPair> _pairs = default!;
        private Dictionary<TKey, TValue>? _cache;
        public Dictionary<TKey, TValue> Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return _cache;
#endif
                _cache ??= new Dictionary<TKey, TValue>();
                _cache.Clear();
                foreach (var pair in _pairs) _cache.Add(pair.Value.Key, pair.Value.Value);
                return _cache;
            }
        }

        IDictionary<TKey, TValue> IReadOnlyAny<IDictionary<TKey, TValue>>.Value => Value;
        IReadOnlyDictionary<TKey, TValue> IReadOnlyAny<IReadOnlyDictionary<TKey, TValue>>.Value => Value;
    }
}