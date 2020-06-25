using System.Collections.Generic;
using Player.Input;
using Saving;
using UnityEngine;

namespace Player.Tracker
{
    public class HighScoreTracker : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        private List<GameObject> _players;

        private void OnEnable()
        {
            _players = _playerManager.GetPlayers();
            // Move to the current high score.
            var newPosition = transform.position;
            // Get the high score for the current level.
            var highScores = SaveLoad.GameSave.GetHighScores();

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
                var playerPosition = player.transform.position;
                // Check if a player is above the high score.
                if (playerPosition.y > t.position.y)
                {
                    // Move to the height of the player.
                    var newPosition = t.position;
                    newPosition.y = playerPosition.y;
                    t.position = newPosition;
                    
                    // Save the high score.
                    var playerName = player.GetComponent<InputController>().GetName();
                    var playerHeight = playerPosition.y;
                    var highScore = new HighScoreData(playerName, playerHeight);
                    SaveLoad.GameSave.AddHighScore(highScore);
                    SaveLoad.Save();
                }
            }
        }
    }
}