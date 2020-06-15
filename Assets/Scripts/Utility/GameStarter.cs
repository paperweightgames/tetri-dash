using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Utility
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private InputActionReference _inputAction;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private UnityEvent _startEvent;

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
            StartGame();
        }

        private void StartGame()
        {
            // Only start with one or more players.
            if (_playerManager.GetPlayerCount() <= 0)
                return;
            
            _startEvent.Invoke();
            // Stop head changing.
            var players = _playerManager.GetPlayers();
            foreach (var player in players)
            {
                player.GetComponentInChildren<PlayerHead>().enabled = false;
            }
            enabled = false;
        }
    }
}