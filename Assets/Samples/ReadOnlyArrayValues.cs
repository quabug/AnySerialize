using System.Collections.Generic;
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
    }
}