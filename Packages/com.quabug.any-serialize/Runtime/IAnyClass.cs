using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace AnySerialize
{
    public interface IAnyClass : IAny {}
    public interface IAnyClass<T> : IAny<T>, IAnyClass {}
    public interface IReadOnlyAnyClass<out T> : IReadOnlyAny<T>, IAnyClass {}

    public static class AnyClassUtility
    {
        public static readonly BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        
        [Pure]
        public static IReadOnlyList<FieldInfo> GetOrderedFields<T>()
        {
            return GetOrderedFields(typeof(T));
        }

        [Pure, ItemNotNull]
        public static IReadOnlyList<T> Reorder<T>([ItemNotNull] IEnumerable<T> items, Func<T, int?> getOrder)
        {
            var orderedItems = new List<T>();
            var sortedCache = new SortedList<int, T>();
            foreach (var item in items)
            {
                var order = getOrder(item);
                if (order.HasValue) sortedCache.Add(order.Value, item);
                else orderedItems.Add(item);
            }
            foreach (var (order, item) in sortedCache) orderedItems.Insert(order, item);
            return orderedItems;
        }

        [Pure]
        public static IReadOnlyList<FieldInfo> GetOrderedFields(Type type)
        {
            var fields = type.GetFields(DefaultBindingFlags);
            return Reorder(fields, field => field.GetCustomAttribute<AnySerializeFieldOrderAttribute>()?.Order);
        }
    }
}