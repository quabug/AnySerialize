using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace AnyProcessor.CodeGen
{
    public static class ReflectionExtension
    {
        [Pure, NotNull]
        public static string ToReadableName([NotNull] this Type type)
        {
            return type.IsGenericType ? Regex.Replace(type.ToString(), @"(\w+)`\d+\[(.*)\]", "$1<$2>") : type.ToString();
        }
        
        [Pure, NotNull, ItemNotNull]
        public static IEnumerable<Type> GetSelfAndAllBases([NotNull] this Type type)
        {
            do
            {
                yield return type;
                type = type.BaseType;
            } while (type != null);
        }
    }
}