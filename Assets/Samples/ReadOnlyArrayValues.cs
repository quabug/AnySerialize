using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlyArrayValues : MonoBehaviour
    {
        [AnySerialize] public int[] IntArray { get; }
        [AnySerialize] public int[][] IntArray2 { get; }
        [AnySerialize] public List<long>[] LongListArray { get; }
        [AnySerialize] public Dictionary<string, int>[] DictionaryArray { get; }
        [AnySerialize] public string[][][] StringArray3 { get; }
        [AnySerialize] public IReadOnlyList<string> StringReadOnlyList { get; }
        [AnySerialize] public PlainClass[][] PlainClasses2 { get; }

        private void Awake()
        {
            Debug.Log($"-------------------------{nameof(ReadOnlyArrayValues)}---------------------------");
            Debug.Log($"{nameof(IntArray)} = {string.Join(",", IntArray)}");
            Debug.Log($"{nameof(IntArray2)} = {string.Join(",", IntArray2.SelectMany(arr => arr))}");
            Debug.Log($"{nameof(LongListArray)} = {string.Join(",", LongListArray.SelectMany(arr => arr))}");
            Debug.Log($"{nameof(DictionaryArray)} = {string.Join(",", DictionaryArray.SelectMany(dict => dict.Select(t => $"{{ {t.Key}=>{t.Value} }}")))}");
            Debug.Log($"{nameof(StringArray3)} = {string.Join(",", StringArray3.SelectMany(arr2 => arr2).SelectMany(arr => arr))}");
            Debug.Log($"{nameof(StringReadOnlyList)} = {string.Join(",", StringReadOnlyList.Select(arr => arr))}");
            Debug.Log($"{nameof(PlainClasses2)} = {string.Join(",", PlainClasses2.SelectMany(arr => arr))}");
        }
    }
}