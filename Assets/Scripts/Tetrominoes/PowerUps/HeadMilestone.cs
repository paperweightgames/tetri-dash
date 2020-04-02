using SaveFile;
using UnityEngine;

namespace Tetrominoes.PowerUps
{
    public class HeadMilestone : MonoBehaviour
    {
        [SerializeField] private Sprite _headToUnlock;
        
        private void Start()
        {
            // Hide if the head is already unlocked.
            var isHeadUnlocked = SaveFileManager.GetInstance().GetActiveSaveFile().IsHeadUnlocked(_headToUnlock);
            if (isHeadUnlocked)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (!other.CompareTag("Player")) return;
            if (other.isTrigger) return;
            // Unlock the new head.
            SaveFileManager.GetInstance().GetActiveSaveFile().UnlockHead(_headToUnlock);
            // Hurt the player.
            gameObject.SetActive(false);
        }
    }
}