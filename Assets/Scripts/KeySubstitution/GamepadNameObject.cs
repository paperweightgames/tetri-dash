using UnityEngine;

namespace KeySubstitution
{
    [CreateAssetMenu(fileName = "Gamepad Name Object", menuName = "ScriptableObjects/GamepadName", order = 0)]
    public class GamepadNameObject : ScriptableObject
    {
        [SerializeField] private GamepadName[] _gamepadNames;

        public string FormatGamepad(string gamepad)
        {
            foreach (var gamepadName in _gamepadNames)
            {
                if (gamepadName.GetGamepadName() == gamepad)
                {
                    return gamepadName.GetShortName();
                }
            }

            return gamepad;
        }
    }
}