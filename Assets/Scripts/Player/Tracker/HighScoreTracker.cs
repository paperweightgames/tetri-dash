using System.Collections.Generic;
using Player.Input;
using SaveFile;
using UnityEngine;

namespace Player.Tracker
{
    public class HighScoreTracker : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        private List<GameObject> _players;
        private SaveFile.SaveFile _saveFile;

        private void OnEnable()
        {
            _players = _playerManager.GetPlayers();
            // Move to the current high score.
            var newPosition = transform.position;
            // Get the high score for the current level.
            _saveFile = SaveFileManager.GetInstance().GetActiveSaveFile();
            var highScores = _saveFile.GetHighScores();

            foreach (var score in highScores)
            {
                if (score.GetScore() > newPosition.y)
                    newPosition.y = score.GetScore();
            }
            
            transform.position = newPosition;
        }

        private void Update()
        {
            var t = transform;
            foreach (var player in _players)
            {
                // Check if a player is above the high score.
                if (player.transform.position.y > t.position.y)
                {
                    // Move to the height of the player.
                    var newPosition = t.position;
                    var playerPosition = player.transform.position;
                    newPosition.y = playerPosition.y;
                    t.position = newPosition;
                    
                    // Save the high score.
                    var playerName = player.GetComponent<InputController>().GetName();
                    var playerHeight = playerPosition.y;
                    var highScore = new HighScoreData(playerName, playerHeight);
                    _saveFile.AddHighScore(highScore);
                }
            }
        }

        private void OnDisable()
        {
            var saveFile = SaveFileManager.GetInstance().GetActiveSaveFile();
            _players = _playerManager.GetPlayers();
            if (_players.Count <= 0)
                return;
            foreach (var player in _players)
            {
                if (!player)
                {
                    print("Player is null!");
                    continue;
                }
                
            }
        }
    }
}