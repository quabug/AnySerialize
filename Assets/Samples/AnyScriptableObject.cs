using UnityEngine;

namespace AnySerialize
{
    [CreateAssetMenu(fileName = "AnySample", menuName = "AnySample", order = 0)]
    public class AnyScriptableObject : ScriptableObject
    {
        [AnySerialize] public int[][] Array2 { get; }
    }
}