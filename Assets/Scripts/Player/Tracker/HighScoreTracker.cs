using System.Collections.Generic;
using SaveFile;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player.Tracker
{
    public class HighScoreTracker : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        private List<GameObject> _players;
        private string _levelName;
        private void Awake()
        {
            _levelName = SceneManager.GetActiveScene().name;
        }

        private void OnEnable()
        {
            _players = _playerManager.GetPlayers();
            // Move to the current high score.
            var newPosition = transform.position;
            // Get the high score for the current level.
            var highScores = SaveFileManager.GetInstance().GetActiveSaveFile().GetHighScores(_levelName);
            foreach (var score in highScores)
            {
                if (score.GetScore() > newPosition.y)
                {
                    newPosition.y = score.GetScore();
                }
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
                    newPosition.y = player.transform.position.y;
                    t.position = newPosition;
                }
            }
        }
    }
}