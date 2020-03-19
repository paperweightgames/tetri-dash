using UnityEngine;

namespace Tetrominoes
{
    public class TetriminoeKillbox : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.isTrigger) return;
            if (other.CompareTag("Tetriminoe"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}