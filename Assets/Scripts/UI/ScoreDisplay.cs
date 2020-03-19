using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private GameObject _scorePrefab;
        private List<PlayerScore> _playerScores = new List<PlayerScore>();
        private List<Text> _scoreTexts = new List<Text>();

        private void OnEnable()
        {
            UpdatePlayers();
        }

        private void Update()
        {
            for (var p = 0; p < _playerScores.Count; p++)
            {
                var playerScore = _playerScores[p].GetHighScore();
                _scoreTexts[p].text = $"{playerScore:0000}";
            }
        }

        private void UpdatePlayers()
        {
            foreach (var scoreText in _scoreTexts)
            {
                Destroy(scoreText.gameObject);
            }
            _scoreTexts.Clear();
            _playerScores.Clear();
            var players = _playerManager.GetPlayers();
            foreach (var player in players)
            {
                _playerScores.Add(player.GetComponent<PlayerScore>());
                var scoreObject = Instantiate(_scorePrefab, transform);
                _scoreTexts.Add(scoreObject.GetComponent<Text>());
            }
        }
    }
}