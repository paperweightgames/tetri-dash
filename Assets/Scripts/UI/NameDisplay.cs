using System.Collections.Generic;
using KeySubstitution;
using Player;
using Player.Input;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NameDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _textPrefab;
        [SerializeField] private PlayerManager _playerManager;
        private readonly List<Text> _textList = new List<Text>();

        private void OnEnable()
        {
            UpdatePlayers();
        }

        public void UpdatePlayers()
        {
            // Clear out current names.
            foreach (var text in _textList)
            {
                Destroy(text.gameObject);
            }
            _textList.Clear();
            
            // Get the list of players.
            var players = _playerManager.GetPlayers();
            foreach (var player in players)
            {
                // Create a text for each player.
                var newTextObject = Instantiate(_textPrefab, transform);
                var textComponent = newTextObject.GetComponent<Text>();
                _textList.Add(textComponent);
                // Set the text to the controls.
                var inputController = player.GetComponent<InputController>();
                var playerName = inputController.GetName();
                textComponent.text = playerName;
                // Set the text colour to the player colour.
                var playerColour = player.GetComponent<PlayerColour>();
                textComponent.color = playerColour.GetColour();
            }
        }
    }
}