using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyCustomOnly)]
    public class AnyNullableClass<T> : IReadOnlyAny<T?>, IAny<T?> where T : class
    {
        [field: SerializeReference] public T? Value { get; set; } = null;
    }
}