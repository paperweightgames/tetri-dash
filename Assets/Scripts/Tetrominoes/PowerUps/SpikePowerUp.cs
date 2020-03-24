using Player;
using UnityEngine;

namespace Tetrominoes.PowerUps
{
    public class SpikePowerUp : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            // Check for player.
            if (!other.gameObject.CompareTag("Player")) return;
            if (other.collider.isTrigger) return;
            // Hurt the player.
            other.gameObject.GetComponent<PlayerHealth>().Hurt(_damage);
            // Destroy(gameObject);
        }
    }
}