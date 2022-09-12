
using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyConstraintType] TAny0> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13, [AnyConstraintType] TAny14> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
        where TAny14 : IReadOnlyAny<T14>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;
        [SerializeField] private TAny14 _field14;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                fields[14].SetValue(_cache, _field14.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13, [AnyConstraintType] TAny14, [AnyConstraintType] TAny15> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
        where TAny14 : IReadOnlyAny<T14>
        where TAny15 : IReadOnlyAny<T15>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;
        [SerializeField] private TAny14 _field14;
        [SerializeField] private TAny15 _field15;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                fields[14].SetValue(_cache, _field14.Value);
                fields[15].SetValue(_cache, _field15.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13, [AnyConstraintType] TAny14, [AnyConstraintType] TAny15, [AnyConstraintType] TAny16> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
        where TAny14 : IReadOnlyAny<T14>
        where TAny15 : IReadOnlyAny<T15>
        where TAny16 : IReadOnlyAny<T16>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;
        [SerializeField] private TAny14 _field14;
        [SerializeField] private TAny15 _field15;
        [SerializeField] private TAny16 _field16;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                fields[14].SetValue(_cache, _field14.Value);
                fields[15].SetValue(_cache, _field15.Value);
                fields[16].SetValue(_cache, _field16.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13, [AnyConstraintType] TAny14, [AnyConstraintType] TAny15, [AnyConstraintType] TAny16, [AnyConstraintType] TAny17> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
        where TAny14 : IReadOnlyAny<T14>
        where TAny15 : IReadOnlyAny<T15>
        where TAny16 : IReadOnlyAny<T16>
        where TAny17 : IReadOnlyAny<T17>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;
        [SerializeField] private TAny14 _field14;
        [SerializeField] private TAny15 _field15;
        [SerializeField] private TAny16 _field16;
        [SerializeField] private TAny17 _field17;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                fields[14].SetValue(_cache, _field14.Value);
                fields[15].SetValue(_cache, _field15.Value);
                fields[16].SetValue(_cache, _field16.Value);
                fields[17].SetValue(_cache, _field17.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyFieldType(nameof(T))] T18, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13, [AnyConstraintType] TAny14, [AnyConstraintType] TAny15, [AnyConstraintType] TAny16, [AnyConstraintType] TAny17, [AnyConstraintType] TAny18> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
        where TAny14 : IReadOnlyAny<T14>
        where TAny15 : IReadOnlyAny<T15>
        where TAny16 : IReadOnlyAny<T16>
        where TAny17 : IReadOnlyAny<T17>
        where TAny18 : IReadOnlyAny<T18>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;
        [SerializeField] private TAny14 _field14;
        [SerializeField] private TAny15 _field15;
        [SerializeField] private TAny16 _field16;
        [SerializeField] private TAny17 _field17;
        [SerializeField] private TAny18 _field18;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                fields[14].SetValue(_cache, _field14.Value);
                fields[15].SetValue(_cache, _field15.Value);
                fields[16].SetValue(_cache, _field16.Value);
                fields[17].SetValue(_cache, _field17.Value);
                fields[18].SetValue(_cache, _field18.Value);
                return (T)_cache;
            }
        }
    }

    [Serializable, AnySerializePriority(10000)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyFieldType(nameof(T))] T18, [AnyFieldType(nameof(T))] T19, [AnyConstraintType] TAny0, [AnyConstraintType] TAny1, [AnyConstraintType] TAny2, [AnyConstraintType] TAny3, [AnyConstraintType] TAny4, [AnyConstraintType] TAny5, [AnyConstraintType] TAny6, [AnyConstraintType] TAny7, [AnyConstraintType] TAny8, [AnyConstraintType] TAny9, [AnyConstraintType] TAny10, [AnyConstraintType] TAny11, [AnyConstraintType] TAny12, [AnyConstraintType] TAny13, [AnyConstraintType] TAny14, [AnyConstraintType] TAny15, [AnyConstraintType] TAny16, [AnyConstraintType] TAny17, [AnyConstraintType] TAny18, [AnyConstraintType] TAny19> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
        where TAny7 : IReadOnlyAny<T7>
        where TAny8 : IReadOnlyAny<T8>
        where TAny9 : IReadOnlyAny<T9>
        where TAny10 : IReadOnlyAny<T10>
        where TAny11 : IReadOnlyAny<T11>
        where TAny12 : IReadOnlyAny<T12>
        where TAny13 : IReadOnlyAny<T13>
        where TAny14 : IReadOnlyAny<T14>
        where TAny15 : IReadOnlyAny<T15>
        where TAny16 : IReadOnlyAny<T16>
        where TAny17 : IReadOnlyAny<T17>
        where TAny18 : IReadOnlyAny<T18>
        where TAny19 : IReadOnlyAny<T19>
    {
        private object _cache;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;
        [SerializeField] private TAny4 _field4;
        [SerializeField] private TAny5 _field5;
        [SerializeField] private TAny6 _field6;
        [SerializeField] private TAny7 _field7;
        [SerializeField] private TAny8 _field8;
        [SerializeField] private TAny9 _field9;
        [SerializeField] private TAny10 _field10;
        [SerializeField] private TAny11 _field11;
        [SerializeField] private TAny12 _field12;
        [SerializeField] private TAny13 _field13;
        [SerializeField] private TAny14 _field14;
        [SerializeField] private TAny15 _field15;
        [SerializeField] private TAny16 _field16;
        [SerializeField] private TAny17 _field17;
        [SerializeField] private TAny18 _field18;
        [SerializeField] private TAny19 _field19;

        public T Value
        {
            get
            {
#if !UNITY_EDITOR
                if (_cache != null) return (T)_cache;
#endif
                _cache ??= new T();
                var fields = AnyClassUtility.GetOrderedFields<T>();
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                fields[8].SetValue(_cache, _field8.Value);
                fields[9].SetValue(_cache, _field9.Value);
                fields[10].SetValue(_cache, _field10.Value);
                fields[11].SetValue(_cache, _field11.Value);
                fields[12].SetValue(_cache, _field12.Value);
                fields[13].SetValue(_cache, _field13.Value);
                fields[14].SetValue(_cache, _field14.Value);
                fields[15].SetValue(_cache, _field15.Value);
                fields[16].SetValue(_cache, _field16.Value);
                fields[17].SetValue(_cache, _field17.Value);
                fields[18].SetValue(_cache, _field18.Value);
                fields[19].SetValue(_cache, _field19.Value);
                return (T)_cache;
            }
        }
    }

}
