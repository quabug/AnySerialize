using System.Collections.Generic;
using Newtonsoft.Json;
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
            this.JsonLog();
        }
    }
}
