using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Tracker
{
    public class HighScore : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private LevelHighScore _levelHighScore;
        private readonly List<Transform> _playerList = new List<Transform>();

        private void Awake()
        {
            transform.position = _levelHighScore.GetHight() * Vector3.up;
        }

        private void OnEnable()
        {
            UpdatePlayers();
        }

        private void UpdatePlayers()
        {
            _playerList.Clear();
            foreach (var player in _playerManager.GetPlayers())
            {
                _playerList.Add(player.transform);
            }
        }

        private void Update()
        {
            var height = _levelHighScore.GetHight();
            foreach (var player in _playerList)
            {
                // Check if a player is higher than the highest point.
                if (!(player.position.y > height)) continue;
                height = player.position.y;
                _levelHighScore.SetHight(height);
            }

            transform.position = height * Vector3.up;
        }
    }
}