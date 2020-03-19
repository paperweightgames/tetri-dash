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
            other.GetComponent<PlayerHealth>().ChangeHealth(-_damage);
            other.transform.position = _center.position;
        }
    }
}