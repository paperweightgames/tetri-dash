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

        public void SetVelocity(Vector3 newVelocity)
        {
            _rb.velocity = newVelocity;
        }
    }
}