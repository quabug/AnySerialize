using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace AnySerialize
{

    using AnySerializeDict = ReadOnlyAnyDictionary<string, int, AnyValue<string>, AnyValue<int>, AnyValue<SerializeKeyValuePair<string, int, AnyValue<string>, AnyValue<int>>>>;
    using Dict = Dictionary<string, int>;
    using AnySerializeArray = ReadOnlyAnyArray<int, AnyValue<int>>;
    using AnySerializeArrayArray = ReadOnlyAnyArray<int[], ReadOnlyAnyArray<int, AnyValue<int>>>;

    public class TestAnySerialize : MonoBehaviour
    {
        [AnySerialize(BaseType = typeof(int))] public int IntValue { get; set; }
        [AnySerialize] public int IntValueRO { get; }
        [AnySerialize] public int IntValueROWithoutBacking => throw new NotImplementedException();
        // [AnySerialize] public Dictionary<string, IReadOnlyDictionary<string, int>> Dictionary { get; }
        // [AnySerialize] public string[][] AnyStringArray { get; }
        public string[][] StringArray;
        
        public A A;
        public B<int> B;
        public B<int[]> BB;
        
        // [AnySerialize] public Vector2 Vector2 { get; }
        
        private void Awake()
        {
            Debug.Log($"{nameof(IntValue)} = {IntValue}");
            Debug.Log($"{nameof(IntValueRO)} = {IntValueRO}");
            IntValue = IntValueRO;
            Debug.Log($"{nameof(IntValue)} = {IntValue}");
            Debug.Log($"{nameof(IntValueROWithoutBacking)} = {IntValueROWithoutBacking}");

            Debug.Log(string.Join(", ", array.Value.SelectMany(a => a)));
            Debug.Log(string.Join(", ", dict.Value.Select(t => $"[{t.Key},{string.Join(", ", t.Value.Select(n => $"[{n.Key},{n.Value}]"))}]")));
            var intB = IntB.Value;
            Debug.Log($"intB: {nameof(B<int>.ReadOnlyTValue)}={intB.ReadOnlyTValue} {nameof(B<int>.TArray)}={string.Join(",", intB.TArray)} {nameof(B<int>.TArrayArray)}={string.Join(",", intB.TArrayArray.SelectMany(a => a))} {nameof(intB.ReadOnlyProperty)}={intB.ReadOnlyProperty}");
            
            Debug.Log(Vector4Any.Value.ToString());
            
            Debug.Log(string.Join(", ", LazyIntArrayArray.Value.Value.SelectMany(a => a)));
        }

        [SerializeField] private ReadOnlyAnyArray<string[], ReadOnlyAnyArray<string, AnyValue<string>>> array;
        [SerializeField] private ReadOnlyAnyDictionary<string, Dict, AnyValue<string>, AnySerializeDict, AnyValue<SerializeKeyValuePair<string, Dict, AnyValue<string>, AnySerializeDict>>> dict;
        [SerializeField] private ReadOnlyAnyClass<B<int>, int, AnyValue<int>, int[], AnySerializeArray, int[][], AnySerializeArrayArray, float, AnyValue<float>> IntB;
        
        [SerializeField] private ReadOnlyAnyClass<Vector4, float, AnyValue<float>, float, AnyValue<float>, float, AnyValue<float>, float, AnyValue<float>> Vector4Any;
        [SerializeField] private ReadOnlyAnyLazy<int[][], AnySerializeArrayArray> LazyIntArrayArray;
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