using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class AnyDateTime : IReadOnlyAny<DateTime>, IAny<DateTime>
    {
        [SerializeField] internal DateTimeKind _dateTimeKind = DateTimeKind.Utc;
        [SerializeField] internal long _ticks;

        public DateTime Value
        {
            get => new(_ticks, _dateTimeKind);
            set => (_dateTimeKind, _ticks) = (value.Kind, value.Ticks);
        }
    }
}