using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerGrounded : MonoBehaviour
    {
        private readonly List<Collider2D> _colliders = new List<Collider2D>();

        private void FixedUpdate()
        {
            _colliders.RemoveAll(item => item == null);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.isTrigger)
                return;
            if (other.CompareTag("Player"))
                return;
            if (!other.CompareTag("Tetriminoe"))
                return;
            if (_colliders.Contains(other))
                return;
            _colliders.Add(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.isTrigger)
                return;
            if (other.CompareTag("Player"))
                return;
            if (!other.CompareTag("Tetriminoe"))
                return;
            if (!_colliders.Contains(other))
                return;
            _colliders.Remove(other);
        }

        public bool IsGrounded()
        {
            return _colliders.Count >= 1;
        }
    }
}
