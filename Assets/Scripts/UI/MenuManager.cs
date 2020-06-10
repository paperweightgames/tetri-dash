using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _activePanel;
        [SerializeField] private EventSystem _eventSystem;
        private GameObject _defaultSelectable;

        private void Start()
        {
            SwitchPanel(_activePanel);
        }

        // A function for switching between panels.
        public void SwitchPanel(GameObject newPanel)
        {
            // Disable the currently active panel.
            _activePanel.SetActive(false);
            // Set the active panel to the new panel.
            _activePanel = newPanel;
            // Enable the new panel.
            newPanel.SetActive(true);
            // Setup the navigation for the new panel.
            SetupNavigation(_activePanel);
        }

        // A function that sets up all navigation for a given panel.
        private void SetupNavigation(GameObject panel)
        {
            // Get a list of all selectable in the current panel.
            var selectables = panel.GetComponentsInChildren<Selectable>().ToList();
            // Remove all selectables that are not interactable.
            selectables.RemoveAll(item => !item.interactable);
            // Set the default selectable to the first one in the panel.
            _defaultSelectable = selectables[0].gameObject;
            // Focus on the first selectable.
            _eventSystem.SetSelectedGameObject(_defaultSelectable);
            // Skip the setup if the panel has only one selectable.
            if (selectables.Count <= 1) return;
            // Setup the navigation for each object.
            for (var i = 0; i < selectables.Count; i++)
            {
                var navigation = new Navigation
                {
                    // Set the up selectable to the previous one in the list, and if at top, set it to the bottom one.
                    selectOnUp = i == 0 ? selectables[selectables.Count - 1] : selectables[i - 1],
                    // Set the down selectable to the next one in the list, and if at bottom, set it to the first one.
                    selectOnDown = i == selectables.Count - 1 ? selectables[0] : selectables[i + 1]
                };
                // Assign the new navigation to the selectable.
                selectables[i].navigation = navigation;
            }
        }

        private void Update()
        {
            // Regain lost focus.
            if (!_eventSystem.currentSelectedGameObject)
            {
                // Focus on the default selectable.
                _eventSystem.SetSelectedGameObject(_defaultSelectable);
            }
        }
    }
}