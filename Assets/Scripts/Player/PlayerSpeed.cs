using Player.Input;
using UnityEngine;

namespace Player
{
    public class PlayerSpeed : MonoBehaviour
    {
        [SerializeField] private float _speedIncrease;
        [SerializeField] private float _speedDecrease;
        [SerializeField] private float _minVelocity;
        [SerializeField] private Vector2 _multiplierBounds;
        private float _speedMultiplier;
        private KeyboardInput _keyboardInput;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _keyboardInput = GetComponent<KeyboardInput>();
        }

        private void FixedUpdate()
        {
            var velocity = _rb.velocity.x;
            print(velocity);
            // Speed up if the player is moving.
            if (velocity >= _minVelocity)
            {
                _speedMultiplier += _speedIncrease * Time.fixedDeltaTime;
            }
            else
            {
                _speedMultiplier -= _speedDecrease * Time.fixedDeltaTime;
            }
            // Clamp the speed multiplier.
            _speedMultiplier = Mathf.Clamp(_speedMultiplier, _multiplierBounds.x, _multiplierBounds.y);
            // Update the player's speed multiplier.
        }
    }
}