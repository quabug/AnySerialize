using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    [CustomPropertyDrawer(typeof(AnyValue<>), true)]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyArray<,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyList<,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyDictionary<,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyLazy<,>))]
    public class AnySingleValueDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            property.NextVisible(enterChildren: true);
            return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.serializedObject.Update();
            
            property.NextVisible(enterChildren: true);
            EditorGUI.PropertyField(position, property, label, includeChildren: true);
            
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}