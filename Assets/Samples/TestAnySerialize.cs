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
            this.JsonLog();
        }
        
        #pragma warning restore UNT0001
    }
    
    public interface IB {}
    public interface IB<T> : IB {}

    [Serializable]
    public class A
    {
        public int Int;
        public float Float;

        public override string ToString()
        {
            return $"{{ {nameof(Int)} = {Int}, {nameof(Float)} = {Float} }}";
        }
    }

    [AnySerializable]
    public class B<T> : IB<T>
    {
        [field: AnySerializeFieldOrder(3)]
        public float ReadOnlyProperty { get; }
        public readonly T ReadOnlyTValue;
        public T[] TArray;
        public T[][] TArrayArray;
        
        public override string ToString()
        {
            return $"{{ {nameof(ReadOnlyProperty)} = {ReadOnlyProperty}, {nameof(ReadOnlyTValue)} = {ReadOnlyTValue}, {nameof(TArray)} = {string.Join(",", TArray)}, {nameof(TArrayArray)} = {string.Join(",", TArrayArray.SelectMany(arr => arr))} }}";
        }
    }
    
    [AnySerializable]
    public record R
    {
        public int Int { get; } = 123;

        public override string ToString()
        {
            return $"{{ {nameof(Int)} = {Int} }}";
        }
    }
}