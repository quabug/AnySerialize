using System;
using System.Reflection;
using UnityEngine;

namespace AnySerialize
{
    [AnySerializable]
    public class Class
    {
        public int Int;
        public float Float;
        public GenericClass<AnotherClass, int> GenericClass { get; }
        public PlainClass PlainClass { get; }
        
        public override string ToString()
        {
            return $"{nameof(Class)}: {nameof(Int)}={Int}, {nameof(Float)}={Float}, {nameof(GenericClass)}={GenericClass}, {nameof(PlainClass)}={PlainClass}";
        }
    }

    [AnySerializable]
    public class AnotherClass
    {
        [AnySerialize(typeof(AnyNullableClass<Class>))]
        public Class ClassProperty { get; }
        public int Value;
        
        public override string ToString()
        {
            return $"{nameof(AnotherClass)}: {nameof(Value)}={Value}, {nameof(ClassProperty)}={(ClassProperty == null ? "null" : ClassProperty.ToString())}";
        }
    }

    [AnySerializable]
    public class GenericClass<T0, T1>
    {
        public T0 Field;
        public T1 Property { get; }
        
        public override string ToString()
        {
            return $"{nameof(GenericClass<T0, T1>)}<{typeof(T0)},{typeof(T1)}>: {nameof(Field)}={Field}, {nameof(Property)}={Property}";
        }
    }

    [Serializable]
    public class PlainClass
    {
        public int Int;
        public float Float;
        public double[] DoubleArray;

        public override string ToString()
        {
            return $"PlainClass: {nameof(Int)}={Int}, {nameof(Float)}={Float}, {nameof(DoubleArray)}={string.Join(",", DoubleArray)}";
        }
    }
    
    public class ReadOnlyClassValues : MonoBehaviour
    {
        [AnySerialize] public Class Foo { get; }
        [AnySerialize] public GenericClass<int, long> GenericClass { get; }
        [AnySerialize] public AnotherClass AnotherClass { get; }
        [AnySerialize] public PlainClass Plain { get; }
        [AnySerialize(typeof(AnyNullableClass<PlainClass>))] public PlainClass PlainNullable { get; }

        private void Awake()
        {
            Debug.Log($"-------------------------{nameof(ReadOnlyClassValues)}---------------------------");
            Debug.Log($"{nameof(Foo)}={Foo}");
            Debug.Log($"{nameof(GenericClass)}={GenericClass}");
            Debug.Log($"{nameof(AnotherClass)}={AnotherClass}");
            Debug.Log($"{nameof(Plain)}={Plain}");
            Debug.Log($"{nameof(PlainNullable)}={(PlainNullable == null ? "null" : PlainNullable.ToString())}");
        }
    }
}