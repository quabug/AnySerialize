using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace AnySerialize
{
    public interface IReadOnlyAnyClass<out T> : IReadOnlyAny<T> {}

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
    
}