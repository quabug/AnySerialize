﻿using System;
using UnityEngine;

namespace AnySerialize
{
    [AnySerializable]
    public readonly struct Struct
    {
        public int A { get; }
        public float B { get; }
        public double? C { get; }
    }
    
    public class ReadOnlySystemValues : MonoBehaviour
    {
        [AnySerialize] public int? NullableInt { get; }
        [AnySerialize] public float? NullableFloat { get; }
        [AnySerialize] public Struct? NullableStruct { get; }

        private void Awake()
        {
            this.JsonLog();
        }
    }
}