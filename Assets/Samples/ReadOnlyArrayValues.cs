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
            this.JsonLog();
        }
    }
}