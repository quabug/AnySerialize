using System;
using UnityEngine.Scripting;

namespace AnySerialize.Tests
{
    public static class NonGeneric
    {
        public interface IInterface {}

        [Serializable]
        public class Object : IInterface
        {
            public float Value;
        }

        [Serializable]
        public class SubObject : Object
        {
            public int[] ValueArray;
        }
    }

    public static class SingleGeneric
    {
        public interface IInterface<T> {}

        [Serializable]
        public class Object<T> : IInterface<T>
        {
            public T Value;
        }

        [Serializable]
        public class SubObject<T> : Object<T>
        {
            public T[] SubValue;
        }

        [Serializable]
        public class DoubleObject : IInterface<double>
        {
            public double Value;
        }
    }

    public static class MultipleGeneric
    {
        [Preserve]
        public interface IInterface<T, U> {}

        [Serializable]
        public class Object<T, U> : IInterface<T, U>
        {
            public T ValueT;
            public U ValueU;
        }

        [Serializable]
        public class SubObject<U, T> : Object<T, U>
        {
            public T[] SubValueT;
            public U[] SubValueU;
        }

        [Serializable]
        public class PartialObject<T> : Object<T, int>
        {
            public double ValueDouble;
        }

        [Serializable]
        public class NonGeneric : Object<float, int>, IInterface<int, float>
        {
            public double ValueDouble;
        }
    }

    public static class Covariance
    {
        public interface IInterface<out T> {}
    }

    public static class Contravariance
    {
        public interface IInterface<in T> {}
    }

    public static class Constraint
    {
        public interface IInterface<T> where T : unmanaged {}
    }
}