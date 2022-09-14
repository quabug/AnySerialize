using System;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace AnySerialize
{
    public class ReadOnlySimpleValues : MonoBehaviour
    {
        [AnySerialize] public int Int { get; }
        [AnySerialize] public int IntWithoutBacking => throw new NotImplementedException();
        [AnySerialize] public float Float { get; }
        [AnySerialize] public double Double { get; }
        [AnySerialize] public long Long => throw new NotImplementedException();
        [AnySerialize] public string String => throw new NotImplementedException();

        private static readonly Regex _backingFieldName = new(@"<(\w*)>k__BackingField");

        private void Awake()
        {
            var type = GetType();
            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var propertyName = _backingFieldName.Match(field.Name).Groups[1].Value;
                var property = type.GetProperty(propertyName)!;
                Debug.Log($"{property.Name}:{field.FieldType} = {property.GetValue(this)}");
            }
        }
    }
}