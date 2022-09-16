using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlyDictionaryValues : MonoBehaviour
    {
        [AnySerialize] public Dictionary<int, string> Dict { get; }
        [AnySerialize] public Dictionary<string, Dictionary<int, float>> Dict2 { get; }
        [AnySerialize] public Dictionary<int, string[]> DictArray { get; }
        [AnySerialize] public Dictionary<int, List<int>> DictList { get; }
        [AnySerialize] public IDictionary<float, int> IDict { get; }
        [AnySerialize] public IReadOnlyDictionary<float, int> ReadOnlyDict { get; }
        [AnySerialize] public Dictionary<int, PlainClass> PlainClasses { get; }

        private void Awake()
        {
            Debug.Log($"-------------------------{nameof(ReadOnlyDictionaryValues)}---------------------------");
            Debug.Log($"{nameof(Dict)} = {Dict.ToJson()}");
            Debug.Log($"{nameof(Dict2)} = {string.Join(",", Dict2.ToJson())}");
            Debug.Log($"{nameof(DictArray)} = {DictArray.ToJson()}");
            Debug.Log($"{nameof(DictList)} = {DictList.ToJson()}");
            Debug.Log($"{nameof(IDict)} = {IDict.ToJson()}");
            Debug.Log($"{nameof(ReadOnlyDict)} = {ReadOnlyDict.ToJson()}");
            Debug.Log($"{nameof(PlainClasses)} = {PlainClasses.ToJson()}");
        }
    }

    public static partial class Extension
    {
        public static string ToReadableString<TKey, TValue>(this Dictionary<TKey, TValue> dict, Func<TKey, string> keyToString = null, Func<TValue, string> valueToString = null)
        {
            return "{" + string.Join(",", dict.Select(t => $"{(keyToString == null ? t.Key : keyToString(t.Key))}=>{(valueToString == null ? t.Value : valueToString(t.Value))}")) + "}";
        }
        
        public static string ToJson<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict)
        {
            return JsonUtility.ToJson(dict);
        }
        
        public static string ToJson<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            return JsonUtility.ToJson(dict);
        }
        
        public static string ToJson<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            return JsonUtility.ToJson(dict);
        }
    }
}
