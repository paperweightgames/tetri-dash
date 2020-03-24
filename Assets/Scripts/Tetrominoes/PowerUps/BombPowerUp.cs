using Player;
using UnityEngine;

namespace Tetrominoes.PowerUps
{
    public class BombPowerUp : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _radius;
        [SerializeField] private float _minDistance;
        [SerializeField] private int _damage = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            // Check for player.
            if (!other.gameObject.CompareTag("Player")) return;
            if (other.collider.isTrigger) return;
            // Push back the players.
            var position = transform.position;
            var results = Physics2D.OverlapCircleAll(position, _radius);
            // Return if it hits nothing.
            if (results.Length <= 0) return;
            // Go through the objects hit.
            foreach (var result in results)
            {
                if (result.isTrigger) continue;
                if (!result.CompareTag("Player")) continue;
                
                // Hurt the player.
                result.GetComponent<PlayerHealth>().Hurt(_damage);
                // Push back the player.
                var rPosition = result.transform.position;
                var force = rPosition - position;
                force.Normalize();
                var distance = Vector3.Distance(rPosition, position);
                distance = Mathf.Max(distance, _minDistance);
                force *= _force / distance;
                // Add the force to the player.
                var rb = result.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.AddForceAtPosition(force, position);
            }
            
            Destroy(gameObject);
        }
    }
}