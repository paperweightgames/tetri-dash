using UnityEngine;

namespace Player
{
    public class PlayerStand : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.isTrigger) return;
            if (!other.CompareTag("Player")) return;
            other.transform.parent = transform;
            var rigidBody = other.GetComponent<Rigidbody2D>();
            rigidBody.bodyType = RigidbodyType2D.Kinematic;
            rigidBody.gravityScale = 0;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.isTrigger) return;
            if (!other.CompareTag("Player")) return;
            other.transform.parent = null;
            var rigidBody = other.GetComponent<Rigidbody2D>();
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
            rigidBody.gravityScale = 1;
        }
    }
}