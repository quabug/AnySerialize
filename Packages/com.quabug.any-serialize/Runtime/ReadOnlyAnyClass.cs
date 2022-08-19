
using System;
using System.Reflection;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6> : IReadOnlyAnyClass<T>
        where T : new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
        where TAny4 : IReadOnlyAny<T4>
        where TAny5 : IReadOnlyAny<T5>
        where TAny6 : IReadOnlyAny<T6>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
                fields[0].SetValue(_cache, _field0.Value);
                fields[1].SetValue(_cache, _field1.Value);
                fields[2].SetValue(_cache, _field2.Value);
                fields[3].SetValue(_cache, _field3.Value);
                fields[4].SetValue(_cache, _field4.Value);
                fields[5].SetValue(_cache, _field5.Value);
                fields[6].SetValue(_cache, _field6.Value);
                fields[7].SetValue(_cache, _field7.Value);
                return (T)_cache;
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13, T14, TAny14> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13, T14, TAny14, T15, TAny15> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13, T14, TAny14, T15, TAny15, T16, TAny16> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13, T14, TAny14, T15, TAny15, T16, TAny16, T17, TAny17> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13, T14, TAny14, T15, TAny15, T16, TAny16, T17, TAny17, T18, TAny18> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

    [Serializable]
    public class ReadOnlyAnyClass<T, T0, TAny0, T1, TAny1, T2, TAny2, T3, TAny3, T4, TAny4, T5, TAny5, T6, TAny6, T7, TAny7, T8, TAny8, T9, TAny9, T10, TAny10, T11, TAny11, T12, TAny12, T13, TAny13, T14, TAny14, T15, TAny15, T16, TAny16, T17, TAny17, T18, TAny18, T19, TAny19> : IReadOnlyAnyClass<T>
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
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;

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
                var fields = this.GetOrderedFields(_fieldFlags);
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
                // TODO: optimize set value of struct by `__makeref` and `SetValueDirect`?
            }
        }
    }

}
