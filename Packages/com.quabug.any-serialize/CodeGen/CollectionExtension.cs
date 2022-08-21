using System;
using System.Collections.Generic;

namespace AnySerialize.CodeGen
{
    internal static class CollectionExtension
    {
        public static int FindIndex<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            var index = 0;
            foreach (var item in items)
            {
                if (predicate(item)) return index;
                index++;
            }
            return -1;
        }
    }
}