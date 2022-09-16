using System;
using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlySimpleValues : MonoBehaviour
    {
        [AnySerialize] public int Int { get; }
        [AnySerialize] public int IntWithoutBacking => throw new NotImplementedException();
        [AnySerialize] public float Float { get; }
        [AnySerialize] public double Double { get; }
        [AnySerialize] public long Long => throw new NotImplementedException();
        [AnySerialize] public string String => throw new NotImplementedException();


        private void Awake()
        {
            this.JsonLog();
        }
    }
}