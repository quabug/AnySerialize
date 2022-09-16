using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlyUnityObjects : MonoBehaviour
    {
        [AnySerialize] public GameObject GameObject { get; }
        [AnySerialize] public AnyScriptableObject ScriptableObject { get; }
        [AnySerialize] public AnimationCurve AnimationCurve { get; }

        private void Awake()
        {
            Debug.Log($"-------------------------{GetType().Name}---------------------------");
            Debug.Log($"{nameof(GameObject)} = {GameObject.name}");
            Debug.Log($"{nameof(ScriptableObject)} = {ScriptableObject.name}");
            Debug.Log($"{nameof(AnimationCurve)} = {AnimationCurve.length}");
        }
    }
}
