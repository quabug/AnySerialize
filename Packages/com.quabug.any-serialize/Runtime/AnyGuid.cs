using System;
using UnityEngine;

namespace AnySerialize
{
    [Serializable]
    public class AnyGuid : IReadOnlyAny<Guid>, IAny<Guid>
    {
        [SerializeField] private string _guid;

        public Guid Value
        {
            get => Guid.Parse(_guid);
            set => _guid = value.ToString();
        }
    }
}