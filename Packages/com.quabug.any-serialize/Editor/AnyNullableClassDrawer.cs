using System;
using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    [CustomPropertyDrawer(typeof(AnyNullableClass<>))]
    public class AnyNullableClassDrawer : PropertyDrawer
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

            var hasValue = property.managedReferenceValue != null;
            
            var toggleWidth = 20;
            var togglePosition = new Rect(position.width - toggleWidth, position.y, toggleWidth, EditorGUIUtility.singleLineHeight);
            var propertyPosition = new Rect(position.x, position.y, position.width - toggleWidth, position.height);
            EditorGUI.PropertyField(propertyPosition, property, label, includeChildren: true);
            var isToggle = EditorGUI.Toggle(togglePosition, hasValue);
            
            if (hasValue && !isToggle)
            {
                property.managedReferenceValue = null;
            }
            else if (!hasValue && isToggle)
            {
                var names = property.managedReferenceFieldTypename.Split(" ");
                var type = Type.GetType($"{names[1]}, {names[0]}");
                property.managedReferenceValue = Activator.CreateInstance(type);
            }
            
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}