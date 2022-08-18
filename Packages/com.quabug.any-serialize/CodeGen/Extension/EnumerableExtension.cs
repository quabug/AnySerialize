using System;
using System.Collections.Generic;

namespace AnySerialize.CodeGen
{
    internal static class EnumerableExtension
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
        
        public static int FindIndexOf<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                    return i;
            }
            return -1;
        }
    }
}