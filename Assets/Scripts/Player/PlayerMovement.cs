using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [Header("Jumping")]
        [SerializeField] private float _jumpHeight;
        [SerializeField] private int _jumpCount;
        [Header("Gravity")]
        [SerializeField] private float _normalGravity;
        [SerializeField] private float _jumpGravity;
        [SerializeField] private PlayerGrounded _playerGrounded;
        [SerializeField] private PlayerHead _playerHead;
        private Vector2 _playerInput;
        private bool _canJump;
        private int _jumps;
        private Rigidbody2D _rb;

        public void SetPlayerInput(Vector2 playerInput)
        {
            _playerInput = playerInput;
        }
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void ResetJumps()
        {
            _jumps = 0;
        }

        private void FixedUpdate()
        {
            if (_playerInput.y <= 0)
            {
                _canJump = true;
            }
            // Reset jumps if grounded.
            if (_playerGrounded.IsGrounded())
            {
                _jumps = 0;
            }
            // Walking.
            var newVelocity = _rb.velocity;
            newVelocity.x = _walkSpeed * _playerInput.x;
            _rb.velocity = newVelocity;
            // Jumping.
            if (_playerInput.y > 0 && _jumps < _jumpCount && _canJump)
            {
                _canJump = false;
                _jumps++;
                if (_playerHead.enabled)
                {
                    _playerHead.NextHead();
                }
                // Reset vertical velocity.
                _rb.velocity = Vector2.right * _rb.velocity.x;
                // Add vertical force.
                var jumpForce = _jumpHeight * Vector2.up;
                _rb.AddForce(jumpForce);
            }
            // Jumping gravity.
            if (_rb.velocity.y > 0 && _playerInput.y <= 0)
            {
                _rb.gravityScale = _jumpGravity;
            }
            else
            {
                _rb.gravityScale = _normalGravity;
            }
        }
    }
}