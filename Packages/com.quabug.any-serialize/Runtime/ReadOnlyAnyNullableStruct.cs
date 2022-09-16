using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyNullableStruct<T, [AnyConstraintType] TAny> : IReadOnlyAny<T?>
        where T : struct
        where TAny : IReadOnlyAny<T>
    {
        [SerializeField] private bool _isNull = true;
        [SerializeField] private TAny _value = default!;
        public T? Value => _isNull ? null : _value.Value;
    }
}