using UnityEngine;

namespace Tetrominoes.SmoothFall
{
    public class SmoothFall : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void SetVelocity(float yVelocity)
        {
            _rb.velocity = Vector2.up * yVelocity;
        }
    }
}