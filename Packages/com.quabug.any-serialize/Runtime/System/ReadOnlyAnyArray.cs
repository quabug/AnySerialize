using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnySerialize
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyArrayPriority)]
    public class ReadOnlyAnyArray<T, [AnyConstraintType] TAny> : IReadOnlyAny<T[]>, IReadOnlyAny<IReadOnlyList<T>>
        where TAny : IReadOnlyAny<T>
    {
        [SerializeField] private TAny[] _value = default!;
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

        IReadOnlyList<T> IReadOnlyAny<IReadOnlyList<T>>.Value => Value;
    }
}