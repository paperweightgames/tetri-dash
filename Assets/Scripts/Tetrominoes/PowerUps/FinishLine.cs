using SaveFile;
using UnityEngine;

namespace Tetrominoes.PowerUps
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private string _levelToUnlock;

        private void Awake()
        {
            // Hide if the level is already unlocked.
            var isLevelUnlocked = SaveFileManager.GetInstance().GetActiveSaveFile().IsLevelUnlocked(_levelToUnlock);
            if (isLevelUnlocked)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (!other.CompareTag("Player")) return;
            if (other.isTrigger) return;
            // Set the level as finished.
            SaveFileManager.GetInstance().GetActiveSaveFile().UnlockLevel(_levelToUnlock);
            // Hurt the player.
            gameObject.SetActive(false);
        }
    }
}