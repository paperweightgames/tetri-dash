using UnityEngine;

namespace Player
{
    public class PlayerStand : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (other.isTrigger) return;
            if (!other.CompareTag("Player")) return;
            
            other.transform.parent = transform;
            var rigidBody = other.GetComponent<Rigidbody2D>();
            rigidBody.bodyType = RigidbodyType2D.Kinematic;
            rigidBody.simulated = false;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.isTrigger) return;
            if (!other.CompareTag("Player")) return;
            
            other.transform.parent = null;
            var rigidBody = other.GetComponent<Rigidbody2D>();
            rigidBody.simulated = true;
        }
    }
}