using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private GameObject _textPrefab;
        private readonly List<PlayerHealth> _healthList = new List<PlayerHealth>();
        private readonly List<Text> _textList = new List<Text>();

        private void OnEnable()
        {
            UpdatePlayers();
        }

        public void Update()
        {
            for (var i = 0; i < _textList.Count; i++)
            {
                var pHealth = _healthList[i];
                var currentHealth = pHealth.GetCurrentHealth();
                var maxHealth = pHealth.GetMaxHealth();
                _textList[i].text = $"{currentHealth}/{maxHealth}";
            }
        }

        private void UpdatePlayers()
        {
            foreach (var text in _textList)
            {
                Destroy(text.gameObject);
            }
            _textList.Clear();
            _healthList.Clear();
            foreach (var player in _playerManager.GetPlayers())
            {
                _healthList.Add(player.GetComponent<PlayerHealth>());
                var newText = Instantiate(_textPrefab, transform);
                _textList.Add(newText.GetComponent<Text>());
            }
        }
    }
}