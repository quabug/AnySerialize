using System;
using UnityEngine;

namespace AnySerialize
{
    public class CycleClasses : MonoBehaviour
    {
        [Serializable]
        public class SelfCycle
        {
            public int Int;
            public SelfCycle Self;
        }

        [AnySerialize(typeof(AnyValue<SelfCycle>))] public SelfCycle Self { get; }
        
        [Serializable]
        public class SelfCycle2
        {
            public int Int;
            [AnySerialize(typeof(AnyNullableClass<SelfCycle2>))] public SelfCycle2 Self2 { get; }
        }
        
        [AnySerialize] public SelfCycle2 Self2 { get; }
    }
}