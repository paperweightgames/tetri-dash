using KeySubstitution;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class KeyboardInput : InputController
    {
        [SerializeField] private Key _upKey;
        [SerializeField] private Key _leftKey;
        [SerializeField] private Key _rightKey;
        [SerializeField] private KeyNameObject _keyNameObject;

        public void SetJumpKey(Key jumpKey)
        {
            _upKey = jumpKey;
        }

        public void SetLeftKey(Key leftKey)
        {
            _leftKey = leftKey;
        }

        public void SetRightKey(Key rightKey)
        {
            _rightKey = rightKey;
        }

        public override string GetName()
        {
            var keys = new[] {_upKey, _leftKey, _rightKey};
            var playerName = _keyNameObject.FormatKeys(keys);
            return playerName;
        }

        protected override void Update()
        {
            // Get player input.
            // Horizontal.
            if (_leftKey != Key.None && Keyboard.current[_leftKey].isPressed)
            {
                PlayerInput.x = -1;
            }
            else if (_rightKey != Key.None && Keyboard.current[_rightKey].isPressed)
            {
                PlayerInput.x = 1;
            }
            else
            {
                PlayerInput.x = 0;
            }
            // Vertical.
            if (_upKey != Key.None && Keyboard.current[_upKey].isPressed)
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
