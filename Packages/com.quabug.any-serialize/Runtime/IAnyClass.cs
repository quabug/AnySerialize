using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace AnySerialize
{
    public interface IAnyClass : IAny {}
    public interface IAnyClass<T> : IAny<T>, IAnyClass {}
    public interface IReadOnlyAnyClass<out T> : IReadOnlyAny<T>, IAnyClass {}

    public static class AnyClassUtility
    {
        public const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        
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
        public static FieldInfo[] GetOrderedFields<T>()
        {
            var fields = typeof(T).GetFields(DefaultBindingFlags);
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