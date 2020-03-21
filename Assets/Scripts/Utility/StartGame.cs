using Player;
using Player.Tracker;
using Tetrominoes;
using Tetrominoes.SmoothFall;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utility
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private InputActionReference _inputAction;
        [SerializeField] private GameObject _hudCanvas;
        [SerializeField] private GameObject _worldCanvas;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private Behaviour[] _behavioursToEnable;

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
            _playerSpawner.enabled = false;
            foreach (var behaviour in _behavioursToEnable)
            {
                behaviour.enabled = true;
            }
            enabled = false;
        }
    }
}