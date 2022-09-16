using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyArrayPriority)]
    public class ReadOnlyAnyList<T, [AnyConstraintType] TAny> : IReadOnlyAny<List<T>>, IReadOnlyAny<IList<T>>
        where TAny : IReadOnlyAny<T>
    {
        [SerializeField] private List<TAny> _value = default!;
        private List<T> _cache = new();
        public List<T> Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache.Count == _value.Count) return _cache;
#endif
                _cache.Clear();
                _cache.AddRange(_value.Select(v => v.Value));
                return _cache;
            }
        }

        IList<T> IReadOnlyAny<IList<T>>.Value => Value;
    }
}