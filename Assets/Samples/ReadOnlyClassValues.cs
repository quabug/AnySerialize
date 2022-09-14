using System.Collections.Generic;
using UnityEngine;

namespace AnySerialize
{
    public class Class
    {
        public int Int;
        public float Float;
        // public GenericClass<AnotherClass, int> GenericClass { get; }
    }

    public class AnotherClass
    {
        public Class ClassProperty { get; }
        public int Value;
        public List<Class> ClassList;
    }

    public class GenericClass<T0, T1>
    {
        public T0 Field;
        public T1 Property { get; }
    }
    
    public class ReadOnlyClassValues : MonoBehaviour
    {
        [AnySerialize] public Class Foo { get; }
    }
}