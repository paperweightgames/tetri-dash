using Player;
using UnityEngine;

namespace Tetrominoes.PowerUps
{
    public class HealthPowerUp : MonoBehaviour
    {
        [SerializeField] private int _healAmount = 1;
        [SerializeField] private GameObject _parent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (!other.CompareTag("Player")) return;
            if (other.isTrigger) return;
            // Add health.
            other.GetComponent<PlayerHealth>().Heal(_healAmount);
            Destroy(_parent.gameObject);
        }
    }
}