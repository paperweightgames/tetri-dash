using UnityEngine;

namespace Tetrominoes.PowerUps
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (!other.CompareTag("Player")) return;
            if (other.isTrigger) return;
            // Hurt the player.
            Destroy(gameObject);
        }
    }
}