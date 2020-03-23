using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Key _upKey = Key.W;
        [SerializeField] private Key _leftKey = Key.A;
        [SerializeField] private Key _rightKey = Key.D;
        [SerializeField] private Vector2 _movementForce;
        [SerializeField] private int _jumpCount = 1;
        [SerializeField] private float _jumpBufferTime = 0.5f;
        [SerializeField] private float _normalGravityScale = 1;
        [SerializeField] private float _jumpGravityScale = 2;
        [SerializeField] private PlayerGrounded _grounded;
        private float _speedMultiplier = 1;
        private bool _jumpKeyHeld;
        private float _timeSinceJump;
        private int _jumps;
        private Vector2Int _playerInput;
        private Rigidbody2D _rb2d;

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

        public IEnumerable<Key> GetKeys()
        {
            return new[] {_upKey, _leftKey, _rightKey};
        }

        public void SetSpeedMultiplier(float speedMultiplier)
        {
            _speedMultiplier = speedMultiplier;
        }
        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Get player input.
            // Horizontal.
            _playerInput.x = 0;
            if (_leftKey != Key.None && Keyboard.current[_leftKey].isPressed)
            {
                _playerInput.x -= 1;
            }
            if (_rightKey != Key.None && Keyboard.current[_rightKey].isPressed)
            {
                _playerInput.x += 1;
            }
            // Vertical.
            if (_upKey != Key.None && Keyboard.current[_upKey].wasPressedThisFrame)
            {
                _playerInput.y = 1;
                _timeSinceJump = 0;
            }

            _jumpKeyHeld = _upKey != Key.None && Keyboard.current[_upKey].isPressed;
            // Jump buffer.
            if (_playerInput.y > 0)
            {
                if (_timeSinceJump < _jumpBufferTime)
                {
                    _timeSinceJump += Time.deltaTime;
                }
                else
                {
                    _playerInput.y = 0;
                }
            }
        }

        private void FixedUpdate()
        {
            // Reset jumps if grounded.
            if (_grounded.IsGrounded())
            {
                _jumps = 0;
            }
            // Horizontal Movement.
            var newVelocity = _rb2d.velocity;
            newVelocity.x = _movementForce.x * _playerInput.x * _speedMultiplier;
            _rb2d.velocity = newVelocity;
            // Jumping.
            if (_playerInput.y > 0 && _jumps < _jumpCount)
            {
                _playerInput.y = 0;
                _jumps++;
                // Reset vertical velocity.
                _rb2d.velocity = Vector2.right * _rb2d.velocity.x;
                // Add vertical force.
                var jumpForce = _speedMultiplier * _movementForce.y * Vector2.up;
                _rb2d.AddForce(jumpForce);
            }
            // Jumping gravity.
            if (_rb2d.velocity.y > 0 && !_jumpKeyHeld)
            {
                _rb2d.gravityScale = _jumpGravityScale;
            }
            else
            {
                _rb2d.gravityScale = _normalGravityScale;
            }
        }
    }
}
