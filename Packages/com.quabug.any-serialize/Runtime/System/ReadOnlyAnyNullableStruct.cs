using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyNullableStruct<T, [AnyConstraintType] TAny> : IReadOnlyAny<T?>
        where T : struct
        where TAny : IReadOnlyAny<T>
    {
        [SerializeField] internal bool _hasValue = true;
        [SerializeField] internal TAny _value = default!;
        public T? Value => _hasValue ? _value.Value : null;
    }
}