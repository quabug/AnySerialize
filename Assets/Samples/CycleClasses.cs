using System;
using UnityEngine;

namespace AnySerialize
{
    public class CycleClasses : MonoBehaviour
    {
        [Serializable, AnySerializable]
        public class SelfCycle
        {
            public int Int;
            public SelfCycle Self;
        }

        [AnySerialize(typeof(AnyValue<SelfCycle>))] public SelfCycle Self { get; }
        
        [AnySerializable]
        public class SelfCycle2
        {
            public int Int;
            [AnySerialize(typeof(AnyNullableClass<SelfCycle2>))] public SelfCycle2 Self2 { get; }
        }
        
        [AnySerialize] public SelfCycle2 Self2 { get; }
    }
}