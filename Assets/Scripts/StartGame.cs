using Player;
using Tetrominoes;
using Tetrominoes.SmoothFall;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputAction;
    [SerializeField] private GameObject _hudCanvas;
    [SerializeField] private GameObject _worldCanvas;
    [SerializeField] private TimeDisplay _timeDisplay;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private SmoothTetriminoeManager _sTetrominoeManager;
    [SerializeField] private TetrominoeManager _tetrominoeManager;
    [SerializeField] private MinimumHeight _minimumHeight;
    [SerializeField] private CenterHeight _centerHeight;

    private void OnEnable()
    {
        _inputAction.action.Enable();
    }

    private void OnDisable()
    {
        _inputAction.action.Disable();
    }

    private void Awake()
    {
        _inputAction.action.performed += OnStartGame;
    }

    private void OnDestroy()
    {
        _inputAction.action.performed -= OnStartGame;
    }

    private void OnStartGame(InputAction.CallbackContext obj)
    {
        StartG();
    }

    private void StartG()
    {
        _hudCanvas.SetActive(true);
        _worldCanvas.SetActive(false);
        if (_tetrominoeManager)
        {
            _tetrominoeManager.enabled = true;
        }
        if (_sTetrominoeManager)
        {
            _sTetrominoeManager.enabled = true;
        }
        _playerSpawner.enabled = false;
        _timeDisplay.enabled = true;
        _minimumHeight.enabled = true;
        _centerHeight.enabled = true;
        enabled = false;
    }
}