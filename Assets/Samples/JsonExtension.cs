using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

namespace AnySerialize
{
    public static class JsonExtension
    {
        private static readonly Regex _backingFieldName = new(@"<(\w+)>k__BackingField");
        
        public static void JsonLog<T>(this T self) where T : MonoBehaviour
        {
            Debug.Log($"-------------------------{self.GetType().Name}---------------------------");
            var type = self.GetType();
            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var propertyName = _backingFieldName.Match(field.Name).Groups[1].Value;
                var property = type.GetProperty(propertyName)!;
                Debug.Log($"{property.Name} = {JsonConvert.SerializeObject(property.GetValue(self))}{Environment.NewLine}{field.FieldType}");
            }
        }
    }
}