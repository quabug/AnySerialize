using System;
using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyArray<TValue, TAny> : IReadOnlyAny<TValue[]> where TAny : IReadOnlyAny<TValue>
    {
        [SerializeField] private TAny[] _Value;
        public TValue[] Value => _Value.Select(v => v.Value).ToArray();
    }
}