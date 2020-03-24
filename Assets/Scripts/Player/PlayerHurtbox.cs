using UnityEngine;

namespace Player
{
    public class PlayerHurtbox : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private Transform _center;
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (!other.CompareTag("Player")) return;
            if (other.isTrigger) return;
            // Hurt the player and reset his position.
            other.GetComponent<PlayerHealth>().Hurt(_damage);
            var newPosition = _center.position;
            newPosition.z = 0;
            other.transform.position = newPosition;
            // Reset y velocity.
            var rb = other.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * rb.velocity.x;
        }
    }
}