using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyNullableStruct<T, [AnyConstraintType] TAny> : IReadOnlyAny<T?>
        where T : struct
        where TAny : IReadOnlyAny<T>
    {
        [SerializeField] private bool _hasValue = true;
        [SerializeField] private TAny _value = default!;
        public T? Value => _hasValue ? _value.Value : null;
    }
}