using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class AnyValue<T> : IAny<T>, IReadOnlyAny<T>
    {
        [SerializeField] private T _value;
        public T Value
        {
            get => _value;
            set => _value = value;
        }
    }
}