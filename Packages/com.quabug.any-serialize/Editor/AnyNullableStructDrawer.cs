using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    using NullableStruct = ReadOnlyAnyNullableStruct<int,AnyValue<int>>;
    
    [CustomPropertyDrawer(typeof(ReadOnlyAnyNullableStruct<,>))]
    public class AnyNullableStructDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            property = property.FindPropertyRelative(nameof(NullableStruct._value));
            return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative(nameof(NullableStruct._value));
            var hasValueProperty = property.FindPropertyRelative(nameof(NullableStruct._hasValue));

            var toggleWidth = 20;
            var togglePosition = new Rect(position.width - EditorGUI.indentLevel * 15f, position.y, toggleWidth, EditorGUIUtility.singleLineHeight);
            var propertyPosition = new Rect(position.x, position.y, position.width - toggleWidth, position.height);
            EditorGUI.PropertyField(togglePosition, hasValueProperty, new GUIContent());
            using (new EditorGUI.DisabledScope(!hasValueProperty.boolValue))
            {
                EditorGUI.PropertyField(propertyPosition, valueProperty, label, includeChildren: true);
            }
        }
    }
}