using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlyListValues : MonoBehaviour
    {
        [AnySerialize] public List<string> StringList { get; }
        [AnySerialize] public List<List<long>> LongList2 { get; }
        [AnySerialize] public List<float[]> FloatArrayList { get; }
        [AnySerialize] public List<Dictionary<string, int>> DictionaryList { get; }
        [AnySerialize] public List<List<List<double>>> DoubleList3 { get; }
        [AnySerialize] public IList<string> StringIList { get; }
        [AnySerialize] public IList<IReadOnlyList<int>> IntReadOnlyListList { get; }
        [AnySerialize] public List<List<PlainClass>> PlainClasses2 { get; }

        private void Awake()
        {
            Debug.Log($"-------------------------{nameof(ReadOnlyListValues)}---------------------------");
            Debug.Log($"{nameof(StringList)} = {string.Join(",", StringList)}");
            Debug.Log($"{nameof(LongList2)} = {string.Join(",", LongList2.SelectMany(arr => arr))}");
            Debug.Log($"{nameof(FloatArrayList)} = {string.Join(",", FloatArrayList.SelectMany(arr => arr))}");
            Debug.Log($"{nameof(DictionaryList)} = {string.Join(",", DictionaryList.SelectMany(dict => dict.Select(t => $"{{ {t.Key}=>{t.Value} }}")))}");
            Debug.Log($"{nameof(DoubleList3)} = {string.Join(",", DoubleList3.SelectMany(arr2 => arr2).SelectMany(arr => arr))}");
            Debug.Log($"{nameof(StringIList)} = {string.Join(",", StringIList)}");
            Debug.Log($"{nameof(IntReadOnlyListList)} = {string.Join(",", IntReadOnlyListList.SelectMany(arr => arr))}");
            Debug.Log($"{nameof(PlainClasses2)} = {string.Join(",", PlainClasses2.SelectMany(arr => arr))}");
        }
    }
}