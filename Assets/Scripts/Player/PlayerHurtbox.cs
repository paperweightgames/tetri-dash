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
            other.GetComponent<PlayerHealth>().ChangeHealth(-_damage);
            var newPosition = _center.position;
            var playerT = other.transform;
            newPosition.z = playerT.position.z;
            playerT.position = newPosition;
        }
    }
}