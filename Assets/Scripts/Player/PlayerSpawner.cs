using System.Collections.Generic;
using System.Linq;
using Player.Input;
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
        [SerializeField] private Key[] _controls = new Key[3];
        [SerializeField] private InputDisplay _inputDisplay;
        [SerializeField] private NameDisplay _nameDisplay;
        [SerializeField] private GameObject _keyboardPrefab;
        [SerializeField] private GameObject _controllerPrefab;
        private readonly List<Gamepad> _gamepads = new List<Gamepad>();
        private int _playerCount;
        private int _currentKey;
        private KeyboardInput _activeKeyboardInput;
        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GetComponent<PlayerManager>();
        }

        private void Update()
        {
            // Spawn controller.
            foreach (var gamepad in Gamepad.all)
            {
                // Ignore already used controllers.
                if (_gamepads.Contains(gamepad)) continue;
                if (!gamepad.buttonSouth.wasPressedThisFrame) continue;
                // Spawn new player.
                _gamepads.Add(gamepad);
                var player = SpawnPlayer(_controllerPrefab);
                player.GetComponent<ControllerInput>().SetGamepad(gamepad);
                _nameDisplay.UpdatePlayers();
                print(gamepad.name);
            }
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
                case 0 when !_activeKeyboardInput:
                    var player = SpawnPlayer(_keyboardPrefab);
                    _activeKeyboardInput = player.GetComponent<KeyboardInput>();
                    _activeKeyboardInput.SetJumpKey(_controls[0]);
                    break;
                case 1:
                    _activeKeyboardInput.SetLeftKey(_controls[1]);
                    break;
                case 2:
                    _activeKeyboardInput.SetRightKey(_controls[2]);
                    // Clean up after the player.
                    _activeKeyboardInput = null;
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
        
        private GameObject SpawnPlayer(GameObject playerPrefab)
        {
            var randomX = Random.Range(-_spawnXBound, _spawnXBound);
            var t = transform;
            var spawnPosition = new Vector2(randomX, t.position.y);
            var newPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.identity, t);
            _playerManager.AddPlayer(newPlayer);
            return newPlayer;
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