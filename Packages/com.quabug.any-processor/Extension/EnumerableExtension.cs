using System;
using System.Collections.Generic;

namespace AnyProcessor.CodeGen
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Yield<T>(this T value)
        {
            yield return value;
        }

        public static int FindLastIndexOf<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (predicate(list[i]))
                    return i;
            }
            return -1;
        }
        
        public static int FindIndexOf<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            var index = 0;
            foreach (var item in items)
            {
                if (predicate(item))
                    return index;
                index++;
            }
            return -1;
        }
    }
}