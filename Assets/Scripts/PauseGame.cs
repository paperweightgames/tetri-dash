using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private InputActionReference _pauseAction;
    [SerializeField] private GameObject _pauseUi;
    private bool _isPaused;

    private void OnEnable()
    {
        _pauseAction.action.Enable();
    }
    private void OnDisable()
    {
        _pauseAction.action.Disable();
    }

    private void Awake()
    {
        _pauseAction.action.performed += OnPaused;
    }

    private void OnPaused(InputAction.CallbackContext obj)
    {
        TogglePause();
    }

    private void OnDestroy()
    {
        _pauseAction.action.performed -= OnPaused;
    }
    
    

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
        _pauseUi.SetActive(_isPaused);
    }
}