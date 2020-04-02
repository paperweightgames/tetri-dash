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

        public void SwitchPanel(GameObject newPanel)
        {
            _activePanel.SetActive(false);
            _activePanel = newPanel;
            newPanel.SetActive(true);
            SetupNavigation(_activePanel);
        }

        private void SetupNavigation(GameObject panel)
        {
            var selectables = panel.GetComponentsInChildren<Selectable>().ToList();
            // Remove all selectables that are not interactable.
            selectables.RemoveAll(item => !item.interactable);
            // Set the default menu.
            _defaultSelectable = selectables[0].gameObject;
            _eventSystem.SetSelectedGameObject(_defaultSelectable);
            // Setup the navigation for each object.
            if (selectables.Count < 2) return;
            for (var i = 0; i < selectables.Count; i++)
            {
                var navigation = selectables[i].navigation;
                navigation.selectOnUp =
                    i == 0 ? selectables[selectables.Count - 1] : selectables[i - 1];
                navigation.selectOnDown = i == selectables.Count - 1 ? selectables[0] : selectables[i + 1];
                selectables[i].navigation = navigation;
            }
        }

        private void Update()
        {
            // Regain lost focus.
            if (!_eventSystem.currentSelectedGameObject)
            {
                _eventSystem.SetSelectedGameObject(_defaultSelectable);
            }
        }
    }
}