using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace AnySerialize.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    [CustomPropertyDrawer(typeof(ReadOnlyAnyClass<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>))]
    public class ReadOnlyAnyClassDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property, label, includeChildren: false);
            if (!property.isExpanded) return;
            
            property.serializedObject.Update();
            
            var classType = property.GetFieldsByPath().Last().field.GetType().GenericTypeArguments[0];
            var fields = classType.GetFields(AnyClassUtility.DefaultBindingFlags);
            var fieldIndex = 0;
            var end = property.GetEndProperty(includeInvisible: false);
            property.NextVisible(enterChildren: true);
            position.y += EditorGUIUtility.singleLineHeight;

            using (new EditorGUI.IndentLevelScope())
            {
                do
                {
                    var fieldName = fields[fieldIndex].Name;
                    if (fieldName.EndsWith("k__BackingField")) fieldName = fieldName.Substring(1, fieldName.Length - "k__BackingField".Length - 2);
                    var fieldLabel = new GUIContent(fieldName);
                    EditorGUI.PropertyField(position, property, fieldLabel, includeChildren: true);
                    position.y += EditorGUI.GetPropertyHeight(property, fieldLabel, includeChildren: true);
                    fieldIndex++;
                } while (property.NextVisible(enterChildren: false) && !SerializedProperty.EqualContents(property, end));
            }
            
            property.serializedObject.ApplyModifiedProperties();
        }
    }

    static class Extension
    {
        private static Regex _arrayData = new Regex(@"^data\[(\d+)\]$");
        
        public static IEnumerable<(object field, FieldInfo fi)> GetFieldsByPath(this SerializedProperty property)
        {
            var obj = (object)property.serializedObject.targetObject;
            FieldInfo fi = null;
            yield return (obj, fi);
            var pathList = property.propertyPath.Split('.');
            for (var i = 0; i < pathList.Length; i++)
            {
                var fieldName = pathList[i];
                if (fieldName == "Array" && i + 1 < pathList.Length && _arrayData.IsMatch(pathList[i + 1]))
                {
                    i++;
                    var itemIndex = int.Parse(_arrayData.Match(pathList[i]).Groups[1].Value);
                    var array = (IList)obj;
                    obj = array != null && itemIndex < array.Count ? array[itemIndex] : null;
                    yield return (obj, fi);
                }
                else
                {
                    var t = Field(obj, obj?.GetType() ?? fi.FieldType, fieldName);
                    obj = t.field;
                    fi = t.fi;
                    yield return t;
                }
            }

            (object field, FieldInfo fi) Field(object declaringObject, Type declaringType, string fieldName)
            {
                var fieldInfo = declaringType.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var fieldValue = declaringObject == null ? null : fieldInfo.GetValue(declaringObject);
                return (fieldValue, fieldInfo);
            }
        }
    }
}