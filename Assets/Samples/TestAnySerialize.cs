using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace AnySerialize
{
    public class TestAnySerialize : MonoBehaviour
    {
        [AnySerialize] public int IntValue { get; set; }
        [AnySerialize] public int IntValueRO { get; }
        [AnySerialize] public int IntValueROWithoutBacking => throw new NotImplementedException();
        [AnySerialize] public Dictionary<string, long> DictionaryStringInt { get; }
        [AnySerialize] public Dictionary<int, Dictionary<string, string>> DictionaryStringDict { get; }
        [AnySerialize] public string[][] AnyStringArray2 { get; }
        [AnySerialize] public int[][][] AnyIntArray3 { get; }
        [AnySerialize] public A[] AnyClassArray { get; }
        
        [AnySerialize] public A A { get; }
        [AnySerialize] public B<int> B { get; }
        [AnySerialize] public B<int[]> BB { get; }
        
        [AnySerialize] public Vector2 Vector2 { get; }
        
        [AnySerialize] public R Record { get; }
        
        [AnySerialize] public Lazy<int> LazyInt { get; }
        
        [AnySerialize] public Lazy<int[]> LazyIntArray { get; }
        [AnySerialize] public Lazy<Dictionary<int, long[]>> LazyDictIntLongArray { get; }
        
        #pragma warning disable UNT0001
        
        private void Awake()
        {
            Debug.Log($"{nameof(IntValue)} = {IntValue}");
            Debug.Log($"{nameof(IntValueRO)} = {IntValueRO}");
            IntValue = IntValueRO;
            Debug.Log($"{nameof(IntValue)} = {IntValue}");
            Debug.Log($"{nameof(IntValueROWithoutBacking)} = {IntValueROWithoutBacking}");
            Debug.Log($"{nameof(DictionaryStringInt)} = {string.Join(",", DictionaryStringInt.Select(t => $"{t.Key}=>{t.Value}"))}");
            Debug.Log($"{nameof(DictionaryStringDict)} = {string.Join(",", DictionaryStringDict.Select(t => $"{t.Key}=>({string.Join(",", t.Value.Select(x => $"{x.Key}=>{x.Value}"))})"))}");
            Debug.Log($"{nameof(AnyStringArray2)} = {string.Join(",", AnyStringArray2.SelectMany(arr => arr))}");
            Debug.Log($"{nameof(AnyIntArray3)} = {string.Join(",", AnyIntArray3.SelectMany(arr2 => arr2).SelectMany(arr => arr))}");
            Debug.Log($"{nameof(AnyClassArray)} = {string.Join(",", AnyClassArray.Select(a => a.ToString()))}");
            Debug.Log($"{nameof(A)} = {A}");
            Debug.Log($"{nameof(B)} = {B}");
            Debug.Log($"{nameof(BB)} = {BB}");
            Debug.Log($"{nameof(Vector2)} = {Vector2}");
            Debug.Log($"{nameof(Record)} = {Record}");
            Debug.Log($"{nameof(LazyInt)} = {LazyInt.Value}");
            Debug.Log($"{nameof(LazyIntArray)} = {string.Join(",", LazyIntArray.Value)}");
            Debug.Log($"{nameof(LazyDictIntLongArray)} = {LazyDictIntLongArray.Value}");
        }
        
        #pragma warning restore UNT0001
    }
    
    public interface IB {}
    public interface IB<T> : IB {}

    [Serializable]
    public class A
    {
        public int Int;
        // [AnySerialize] public string[][] StringArray { get; }
        public float Float;

        public override string ToString()
        {
            return $"{{ {nameof(Int)} = {Int}, {nameof(Float)} = {Float} }}";
        }
    }

    [Serializable]
    public class B<T> : IB<T>
    {
        public readonly T ReadOnlyTValue;
        public T[] TArray;
        public T[][] TArrayArray;
        public float ReadOnlyProperty { get; }
        
        public override string ToString()
        {
            return $"{{ {nameof(ReadOnlyProperty)} = {ReadOnlyProperty}, {nameof(ReadOnlyTValue)} = {ReadOnlyTValue}, {nameof(TArray)} = {string.Join(",", TArray)}, {nameof(TArrayArray)} = {string.Join(",", TArrayArray.SelectMany(arr => arr))} }}";
        }
    }
    
    [Serializable]
    public record R
    {
        public int Int { get; } = 123;

        public override string ToString()
        {
            return $"{{ {nameof(Int)} = {Int} }}";
        }
    }
}