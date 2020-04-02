using System.Collections.Generic;
using SaveFile;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField] private LevelList _levelList;
        [SerializeField] private GameObject _buttonPrefab;
        private LoadScene _loadScene;
        private readonly List<GameObject> _levelButtons = new List<GameObject>();

        private void Awake()
        {
            _loadScene = GetComponent<LoadScene>();
        }

        private void OnEnable()
        {
            UpdateLevels();
        }

        private void UpdateLevels()
        {
            // Get the Save File Manager.
            var levels = _levelList.GetLevels();
            var unlockedLevels = SaveFileManager.GetInstance().GetActiveSaveFile().GetLevels();
            // Remove all current buttons.
            foreach (var button in _levelButtons)
            {
                DestroyImmediate(button);
            }
            _levelButtons.Clear();
            // Create new buttons.
            foreach (var level in levels)
            {
                // Create the new button object.
                var newButton = Instantiate(_buttonPrefab, transform);
                // Add the new button to the list.
                _levelButtons.Add(newButton);
                // Move the button.
                newButton.transform.SetSiblingIndex(transform.childCount - 2);
                // Make the button change the scene.
                var buttonComponent = newButton.GetComponent<Button>();
                UnityAction loadAction = delegate
                {
                    _loadScene.Load(level);
                };
                buttonComponent.onClick.AddListener(loadAction);
                // Change its name.
                var buttonText = newButton.GetComponentInChildren<Text>();
                // Check if the level is unlocked.
                if (unlockedLevels.Contains(level))
                {
                    buttonText.text = level;
                }
                else
                {
                    buttonText.text = "???";
                    buttonComponent.interactable = false;
                }
            }
        }
    }
}