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
        [AnySerialize] public IList<string> StringIList { get; }
        [AnySerialize] public IList<IReadOnlyList<int>> IntReadOnlyListList { get; }
        [AnySerialize] public List<List<PlainClass>> PlainClasses2 { get; }

        private void Awake()
        {
            this.JsonLog();
        }
    }
}