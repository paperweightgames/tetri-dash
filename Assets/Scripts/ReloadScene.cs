using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] private InputActionReference _reloadAction;

    private void Start()
    {
        _reloadAction.action.performed += OnReload;
    }

    private void OnDestroy()
    {
        _reloadAction.action.performed -= OnReload;
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        Reload();
    }

    private void OnEnable()
    {
        _reloadAction.action.Enable();
    }

    private void OnDisable()
    {
        _reloadAction.action.Disable();
    }

    private void Reload()
    {
        Time.timeScale = 1;
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
