using Saving;
using UnityEngine;

namespace Milestones
{
    public class HeadMilestone : MonoBehaviour
    {
        [SerializeField] private int _headToUnlock;
        
        private void Start()
        {
            // Hide if the head is already unlocked.
            var isHeadUnlocked = SaveLoad.GameSave.IsHeadUnlocked(_headToUnlock);
            gameObject.SetActive(!isHeadUnlocked);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check for player.
            if (!other.CompareTag("Player"))
                return;
            if (other.isTrigger)
                return;
            // Unlock the new head.
            SaveLoad.GameSave.UnlockHead(_headToUnlock);
            // Hurt the player.
            gameObject.SetActive(false);
        }
    }
}