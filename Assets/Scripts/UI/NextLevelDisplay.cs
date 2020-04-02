using SaveFile;
using UnityEngine;

namespace UI
{
    public class NextLevelDisplay : MonoBehaviour
    {
        [SerializeField] private string _nextLevel;
        [SerializeField] private GameObject _nextLevelButton;

        private void OnEnable()
        {
            var isLevelFinished = SaveFileManager.GetInstance().GetActiveSaveFile().IsLevelUnlocked(_nextLevel);
            // Disable if the level is not finished.
            _nextLevelButton.SetActive(isLevelFinished);
        }
    }
}