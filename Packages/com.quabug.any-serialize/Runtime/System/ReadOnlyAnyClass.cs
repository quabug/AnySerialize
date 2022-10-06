
using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
    {
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny17> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;
        [SerializeField] private TAny17 _field17 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyFieldType(nameof(T))] T18, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny17, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny18> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;
        [SerializeField] private TAny17 _field17 = default!;
        [SerializeField] private TAny18 _field18 = default!;

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

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyClass<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyFieldType(nameof(T))] T18, [AnyFieldType(nameof(T))] T19, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny17, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny18, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny19> : IReadOnlyAnyClass<T>
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
        private object? _cache;
        
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;
        [SerializeField] private TAny17 _field17 = default!;
        [SerializeField] private TAny18 _field18 = default!;
        [SerializeField] private TAny19 _field19 = default!;

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
