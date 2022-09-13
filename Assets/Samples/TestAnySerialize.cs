using System;
using System.Collections.Generic;
using UnityEngine;


namespace AnySerialize
{
    public class TestAnySerialize : MonoBehaviour
    {
        [AnySerialize] public int IntValue { get; set; }
        [AnySerialize] public int IntValueRO { get; }
        [AnySerialize] public int IntValueROWithoutBacking => throw new NotImplementedException();
        [AnySerialize] public Dictionary<int, long> DictionaryStringInt { get; }
        [AnySerialize] public string[][] AnyStringArray2 { get; }
        [AnySerialize] public int[][][] AnyIntArray3 { get; }
        [AnySerialize] public A[] AnyClassArray { get; }
        
        [AnySerialize] public A A { get; }
        [AnySerialize] public B<int> B { get; }
        [AnySerialize] public B<int[]> BB { get; }
        
        [AnySerialize] public Vector2 Vector2 { get; }
        
        private void Awake()
        {
            Debug.Log($"{nameof(IntValue)} = {IntValue}");
            Debug.Log($"{nameof(IntValueRO)} = {IntValueRO}");
            IntValue = IntValueRO;
            Debug.Log($"{nameof(IntValue)} = {IntValue}");
            Debug.Log($"{nameof(IntValueROWithoutBacking)} = {IntValueROWithoutBacking}");
        }
    }
    
    public interface IB {}
    public interface IB<T> : IB {}

    [Serializable]
    public class A
    {
        public int Int;
        // [AnySerialize] public string[][] StringArray { get; }
        public float Float;
    }

    [Serializable]
    public class B<T> : IB<T>
    {
        public readonly T ReadOnlyTValue;
        public T[] TArray;
        public T[][] TArrayArray;
        public float ReadOnlyProperty { get; }
    }
}