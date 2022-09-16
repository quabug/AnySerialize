using System.Linq;
using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlyUnityObjects : MonoBehaviour
    {
        [AnySerialize] public GameObject GameObject { get; }
        [AnySerialize] public AnyScriptableObject ScriptableObject { get; }
        [AnySerialize] public AnimationCurve AnimationCurve { get; }
        [AnySerialize] public GameObject[][] GameObjectArray2 { get; }

        private void Awake()
        {
            Debug.Log($"-------------------------{GetType().Name}---------------------------");
            Debug.Log($"{nameof(GameObject)} = {GameObject.name}");
            Debug.Log($"{nameof(ScriptableObject)} = {ScriptableObject.name}");
            Debug.Log($"{nameof(AnimationCurve)} = {AnimationCurve.length}");
            Debug.Log($"{nameof(GameObjectArray2)} = {string.Join(",", GameObjectArray2.SelectMany(arr => arr).Select(obj => obj.name))}");
        }
    }
}
