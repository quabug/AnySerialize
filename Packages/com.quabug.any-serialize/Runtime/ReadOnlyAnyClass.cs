using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace AnySerialize
{
    public interface IReadOnlyAnyClass<T> {}

    public static class AnyClassUtility
    {
        public const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        
        [Pure]
        public static FieldInfo[] GetOrderedFields<T>(this IReadOnlyAnyClass<T> _, BindingFlags fieldFlags)
        {
            return GetOrderedFields<T>(fieldFlags);
        }

        [Pure]
        public static T[] Reorder<T>(this T[] array, IEnumerable<int> newIndices)
        {
            var newArray = new T[array.Length];
            var index = 0;
            foreach (var newIndex in newIndices)
            {
                newArray[newIndex] = array[index];
                index++;
            }
            Assert.AreEqual(index, array.Length);
            Assert.IsTrue(newArray.All(element => element != null));
            return array;
        }

        [Pure]
        public static FieldInfo[] GetOrderedFields<T>(BindingFlags fieldFlags)
        {
            var fields = typeof(T).GetFields(fieldFlags);
            var newIndices = fields
                .Select((f, i) => (index: i, order: f.GetCustomAttribute<AnySerializeFieldOrderAttribute>()?.Order ?? i))
                .OrderBy(t => t.order)
                .Select(t => t.index)
            ;
            fields = fields.Reorder(newIndices);
            return fields;
        }
    }
    
    [Serializable]
    public class ReadOnlyAnyClass<T, T0, T1, T2, T3, TAny0, TAny1, TAny2, TAny3> : IReadOnlyAnyClass<T>, IReadOnlyAny<T>
        where T : class, new()
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyClass() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyClass(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;

        public T Value
        {
            get
            {
                var fields = this.GetOrderedFields(_fieldFlags);
                var value = new T();
                fields[0].SetValue(value, _field0.Value);
                fields[1].SetValue(value, _field1.Value);
                fields[2].SetValue(value, _field2.Value);
                fields[3].SetValue(value, _field3.Value);
                return value;
            }
        }
    }
    
    [Serializable]
    public class ReadOnlyAnyStruct<T, T0, T1, T2, T3, TAny0, TAny1, TAny2, TAny3> : IReadOnlyAnyClass<T>, IReadOnlyAny<T>
        where T : struct
        where TAny0 : IReadOnlyAny<T0>
        where TAny1 : IReadOnlyAny<T1>
        where TAny2 : IReadOnlyAny<T2>
        where TAny3 : IReadOnlyAny<T3>
    {
        private readonly BindingFlags _fieldFlags;
        public ReadOnlyAnyStruct() : this(AnyClassUtility.DefaultBindingFlags) {}
        public ReadOnlyAnyStruct(BindingFlags fieldFlags) => _fieldFlags = fieldFlags;
        
        [SerializeField] private TAny0 _field0;
        [SerializeField] private TAny1 _field1;
        [SerializeField] private TAny2 _field2;
        [SerializeField] private TAny3 _field3;

        public T Value
        {
            get
            {
                var fields = this.GetOrderedFields(_fieldFlags);
                var value = default(T);
#if ENABLE_IL2CPP
                object valueObject = value;
                fields[0].SetValue(valueObject, _field0.Value);
                fields[1].SetValue(valueObject, _field1.Value);
                fields[2].SetValue(valueObject, _field2.Value);
                fields[3].SetValue(valueObject, _field3.Value);
                return (T)valueObject;
#else
                var valueRef = __makeref(value);
                fields[0].SetValueDirect(valueRef, _field0.Value);
                fields[1].SetValueDirect(valueRef, _field1.Value);
                fields[2].SetValueDirect(valueRef, _field2.Value);
                fields[3].SetValueDirect(valueRef, _field3.Value);
                return value;
#endif
            }
        }
    }
}