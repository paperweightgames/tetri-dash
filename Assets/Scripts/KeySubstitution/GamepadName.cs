using System;
using UnityEngine;

namespace KeySubstitution
{
    [Serializable]
    public class GamepadName
    {
        [SerializeField] private string _gamepadName;
        [SerializeField] private string _shortName;

        public string GetGamepadName()
        {
            return _gamepadName;
        }

        public string GetShortName()
        {
            return _shortName;
        }
    }
}