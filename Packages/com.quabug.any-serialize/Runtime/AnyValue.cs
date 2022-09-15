using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable, AnySerializePriority(100000)]
    public class AnyValue<T> : IAny<T>, IReadOnlyAny<T>
    {
        [SerializeField] private T _value = default!;
        public T Value
        {
            get => _value;
            set => _value = value;
        }
    }
}