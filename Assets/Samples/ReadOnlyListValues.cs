using System.Collections.Generic;
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
    }
}