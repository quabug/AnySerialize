using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class AnyTimeSpan : IReadOnlyAny<TimeSpan>, IAny<TimeSpan>
    {
        [SerializeField] internal Unit _displayUnit = Unit.Seconds;
        [SerializeField] internal long _ticks;

        public TimeSpan Value
        {
            get => TimeSpan.FromTicks(_ticks);
            set => _ticks = value.Ticks;
        }

        internal enum Unit
        {
            Ticks,
            Milliseconds,
            Seconds,
            Minutes,
            Hours,
            Days
        }
    }
}