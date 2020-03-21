using UnityEngine;
using UnityEngine.InputSystem;

namespace Utility
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private InputActionReference _pauseAction;
        [SerializeField] private GameObject _pauseUi;
        [SerializeField] private GameObject _cursorUi;
        private bool _isPaused;

        private void Awake()
        {
            _pauseAction.action.performed += TogglePause;
            SetPause(false);
        }

        private void OnEnable()
        {
            _pauseAction.action.Enable();
        }

        private void OnDisable()
        {
            _pauseAction.action.Disable();
        }

        private void OnDestroy()
        {
            _pauseAction.action.performed -= TogglePause;
        }

        private void TogglePause(InputAction.CallbackContext obj)
        {
            SetPause(!_isPaused);
        }

        public void SetPause(bool isPaused)
        {
            _isPaused = isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
            _pauseUi.SetActive(_isPaused);
            _cursorUi.SetActive(_isPaused);
        }
    }
}