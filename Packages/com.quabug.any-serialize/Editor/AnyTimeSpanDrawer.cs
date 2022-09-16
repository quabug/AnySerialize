using System;
using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    [CustomPropertyDrawer(typeof(AnyTimeSpan))]
    public class AnyTimeSpanDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var ticks = property.FindPropertyRelative(nameof(AnyTimeSpan._ticks));
            var unit = property.FindPropertyRelative(nameof(AnyTimeSpan._displayUnit));
            var unitEnum = (AnyTimeSpan.Unit)unit.enumValueIndex;
            
            var buttonWidth = 80;
            var labelPosition = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height);
            var buttonPosition = new Rect(position.width - buttonWidth, position.y, buttonWidth, position.height);
            var propertyPosition = new Rect(labelPosition.width + 20, position.y, position.width - buttonWidth - labelPosition.width - 20, position.height);
            EditorGUI.LabelField(labelPosition, label);
            EditorGUI.PropertyField(buttonPosition, unit, new GUIContent());
            if (unitEnum == AnyTimeSpan.Unit.Ticks)
            {
                ticks.longValue = EditorGUI.LongField(propertyPosition, ticks.longValue);
            }
            else
            {
                var time = EditorGUI.DoubleField(propertyPosition, ToDouble(ticks.longValue, unitEnum));
                ticks.longValue = FromDouble(time, unitEnum).Ticks;
            }

            static double ToDouble(long ticks, AnyTimeSpan.Unit unit)
            {
                var timespan = TimeSpan.FromTicks(ticks);
                return unit switch
                {
                    AnyTimeSpan.Unit.Milliseconds => timespan.TotalMilliseconds,
                    AnyTimeSpan.Unit.Seconds => timespan.TotalSeconds,
                    AnyTimeSpan.Unit.Minutes => timespan.TotalMinutes,
                    AnyTimeSpan.Unit.Hours => timespan.TotalHours,
                    AnyTimeSpan.Unit.Days => timespan.TotalDays,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            static TimeSpan FromDouble(double time, AnyTimeSpan.Unit unit)
            {
                return unit switch
                {
                    AnyTimeSpan.Unit.Milliseconds => TimeSpan.FromMilliseconds(time),
                    AnyTimeSpan.Unit.Seconds => TimeSpan.FromSeconds(time),
                    AnyTimeSpan.Unit.Minutes => TimeSpan.FromMinutes(time),
                    AnyTimeSpan.Unit.Hours => TimeSpan.FromHours(time),
                    AnyTimeSpan.Unit.Days => TimeSpan.FromDays(time),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}