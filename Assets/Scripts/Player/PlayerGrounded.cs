using UnityEngine;

namespace Player
{
    public class PlayerGrounded : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private Transform _parent;
        private bool _isGrounded;

        private void Start()
        {
            _parent = _player.parent;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) return;
            if (other.CompareTag("Tetriminoe"))
            {
                // _player.parent = other.transform;
            }
            _isGrounded = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) return;
            if (other.CompareTag("Tetriminoe"))
            {
                _player.parent = _parent;
            }
            _isGrounded = false;
        }

        public bool IsGrounded()
        {
            return _isGrounded;
        }
    }
}
