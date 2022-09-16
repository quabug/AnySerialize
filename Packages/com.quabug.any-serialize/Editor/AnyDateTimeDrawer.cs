using System;
using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    [CustomPropertyDrawer(typeof(AnyDateTime))]
    public class AnyDateTimeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var ticks = property.FindPropertyRelative(nameof(AnyDateTime._ticks));
            var kind = property.FindPropertyRelative(nameof(AnyDateTime._dateTimeKind));
            var kindEnum = (DateTimeKind)kind.enumValueIndex;
            var dateTime = new DateTime(ticks.longValue, kindEnum);
            
            var labelPosition = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height);
            var propertyPosition = new Rect(labelPosition.width + 20, position.y, position.width, position.height);
            EditorGUI.LabelField(labelPosition, label);
            
            var year = IntField(dateTime.Year, "Y", 4, min: 1);
            var month = IntField(dateTime.Month, "M", 2, min: 1, max: 12);
            var day = IntField(dateTime.Day, "D", 2, min: 1, max: 31);
            var hour = IntField(dateTime.Hour, "H", 2, min: 0, max: 23);
            var minute = IntField(dateTime.Minute, "M", 2, min: 0, max: 59);
            var second = IntField(dateTime.Second, "S", 2, min: 0, max: 59);
            var millisecond = IntField(dateTime.Millisecond, "MS", 3, min: 0, max: 999);

            var kindWidth = 50;
            propertyPosition.width = kindWidth;
            EditorGUI.PropertyField(propertyPosition, kind, new GUIContent());
            
            ticks.longValue = new DateTime(year, month, day, hour, minute, second, millisecond, kindEnum).Ticks;

            propertyPosition.x += kindWidth;
            if (GUI.Button(propertyPosition, "now"))
            {
                ticks.longValue = DateTime.Now.Ticks;
                kind.enumValueIndex = (int)DateTimeKind.Local;
            }

            int IntField(int number, string name, int digits, int min = 0, int max = int.MaxValue)
            {
                var singleNumberWidth = 10;
                var width = digits * singleNumberWidth;
                propertyPosition.width = width;
                number = EditorGUI.IntField(propertyPosition, number);
                number = Math.Clamp(number, min, max);
                propertyPosition.x += width;
                EditorGUI.LabelField(propertyPosition, name);
                propertyPosition.x += name.Length * singleNumberWidth;
                return number;
            }
        }
    }
}
