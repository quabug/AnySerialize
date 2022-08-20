using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace AnySerialize.CodeGen
{
    internal static class ReflectionExtension
    {
        [Pure, NotNull]
        public static string ToReadableName([NotNull] this Type type)
        {
            return type.IsGenericType ? Regex.Replace(type.ToString(), @"(\w+)`\d+\[(.*)\]", "$1<$2>") : type.ToString();
        }
    }
}