using KeySubstitution;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class ControllerInput : InputController
    {
        [SerializeField] private GamepadNameObject _gamepadNameObject;
        private Gamepad _gamepad;

        public void SetGamepad(Gamepad gamepad)
        {
            _gamepad = gamepad;
        }

        public override string GetName()
        {
            return _gamepadNameObject.FormatGamepad(_gamepad.name);
        }

        protected override void Update()
        {
            // Only update movement if the gamepad is assigned.
            if (_gamepad == null) return;
            
            if (_gamepad.leftStick.left.isPressed || _gamepad.dpad.left.isPressed)
            {
                PlayerInput.x = -1;
            }
            else if (_gamepad.leftStick.right.isPressed || _gamepad.dpad.right.isPressed)
            {
                PlayerInput.x = 1;
            }
            else
            {
                PlayerInput.x = 0;
            }
            // Vertical.
            if (_gamepad.buttonSouth.isPressed)
            {
                PlayerInput.y = 1;
            }
            else
            {
                PlayerInput.y = 0;
            }
            
            base.Update();
        }
    }
}