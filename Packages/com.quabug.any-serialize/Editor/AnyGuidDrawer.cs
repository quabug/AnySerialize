using System;
using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    [CustomPropertyDrawer(typeof(AnyGuid))]
    public class AnyGuidDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.NextVisible(enterChildren: true);
            var buttonWidth = 40;
            var propertyPosition = new Rect(position.x, position.y, position.width - buttonWidth - 20, position.height);
            var buttonPosition = new Rect(position.width - buttonWidth, position.y, buttonWidth, position.height);
            EditorGUI.PropertyField(propertyPosition, property, label);
            if (GUI.Button(buttonPosition, "new")) property.stringValue = Guid.NewGuid().ToString();
        }
    }
}