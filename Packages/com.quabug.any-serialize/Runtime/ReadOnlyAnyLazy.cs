using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyLazy<T, [AnyConstraintType] TAny> : IReadOnlyAny<Lazy<T>> where TAny : IReadOnlyAny<T>
    {
        [SerializeField] private TAny _value = default!;
        public Lazy<T> Value { get; }
        public ReadOnlyAnyLazy() => Value = new Lazy<T>(() => _value.Value);
    }
}