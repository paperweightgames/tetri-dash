using System.Collections.Generic;
using System.Linq;
using Player.Movement;
using UI;
using UnityEngine.InputSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private int _maxPlayers;
        [SerializeField] private float _spawnXBound;
        [SerializeField] private List<Key> _keysToIgnore;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Key[] _controls = new Key[3];
        [SerializeField] private InputDisplay _inputDisplay;
        [SerializeField] private NameDisplay _nameDisplay;
        private int _playerCount;
        private int _currentKey;
        private PlayerMovement _activePlayerMovement;
        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GetComponent<PlayerManager>();
        }

        private void Update()
        {
            // Don't run if max number of players reached.
            if (_playerCount >= _maxPlayers) return;
            // Skip if no key was pressed.
            if (!Keyboard.current.anyKey.wasPressedThisFrame) return;
            var pressedKey = GetPressedKey();
            // Skip if the key is already used.
            if (pressedKey == Key.None || _controls.Contains(pressedKey)) return;
            _controls[_currentKey] = pressedKey;
            IgnoreKey(pressedKey);
            
            switch (_currentKey)
            {
                // Once the jump key is pressed, create a new player.
                case 0 when !_activePlayerMovement:
                    SpawnPlayer();
                    _activePlayerMovement.SetJumpKey(_controls[0]);
                    break;
                case 1:
                    _activePlayerMovement.SetLeftKey(_controls[1]);
                    break;
                case 2:
                    _activePlayerMovement.SetRightKey(_controls[2]);
                    // Clean up after the player.
                    _activePlayerMovement = null;
                    _controls = new Key[3];
                    _playerCount++;
                    break;
            }
            _inputDisplay.AdvancePrompt();
            _nameDisplay.UpdatePlayers();
            _currentKey++;
            if (_currentKey >= _controls.Length)
            {
                _currentKey = 0;
            }
        }

        private void IgnoreKey(Key keyToIgnore)
        {
            if (!_keysToIgnore.Contains(keyToIgnore))
            {
                _keysToIgnore.Add(keyToIgnore);
            }
        }
        
        private void SpawnPlayer()
        {
            var randomX = Random.Range(-_spawnXBound, _spawnXBound);
            var t = transform;
            var spawnPosition = new Vector2(randomX, t.position.y);
            var newPlayer = Instantiate(_playerPrefab, spawnPosition, Quaternion.identity, t);
            _playerManager.AddPlayer(newPlayer);
            _activePlayerMovement = newPlayer.GetComponent<PlayerMovement>();
        }
        private Key GetPressedKey()
        {
            foreach (var key in Keyboard.current.allKeys)
            {
                if (key.wasPressedThisFrame && !_keysToIgnore.Contains(key.keyCode))
                {
                    return key.keyCode;
                }
            }

            return Key.None;
        }
    }
}