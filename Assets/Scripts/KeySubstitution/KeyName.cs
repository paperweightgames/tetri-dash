using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KeySubstitution
{
    [Serializable]
    public class KeyName
    {
        [SerializeField] private Key _key;
        [SerializeField] private string _name;

        public Key GetKey()
        {
            return _key;
        }

        public string GetName()
        {
            return _name;
        }
    }
}