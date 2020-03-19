using System.Collections.Generic;
using UnityEngine;

namespace Tetrominoes
{
    public class FallCheck : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _collidedObjects = new List<GameObject>();

        public bool IsClear()
        {
            return _collidedObjects.Count == 0;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Ignore the player.
            if (other.CompareTag("Player")) return;
            if (!_collidedObjects.Contains(other.gameObject))
            {
                _collidedObjects.Add(other.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            // Ignore the player.
            if (other.CompareTag("Player")) return;
            if (_collidedObjects.Contains(other.gameObject))
            {
                _collidedObjects.Remove(other.gameObject);
            }
        }
    }
}
