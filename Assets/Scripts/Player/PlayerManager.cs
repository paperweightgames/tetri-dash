﻿using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _players;
        [SerializeField] private Color[] _playerColours;
        [SerializeField] private GameObject _restartCanvas;

        public int GetPlayerCount()
        {
            return _players.Count;
        }

        public int GetMaxCount()
        {
            return _playerColours.Length;
        }

        public List<GameObject> GetPlayers()
        {
            return _players;
        }

        public void AddPlayer(GameObject newPlayer)
        {
            // Assign the player to a colour.
            var playerColour = _playerColours[_players.Count];
            newPlayer.GetComponent<PlayerColour>().SetColour(playerColour);
            
            _players.Add(newPlayer);
        }

        public void CheckGameOver()
        {
            // Check for live players.
            foreach (var player in _players)
            {
                if (player.activeSelf) return;
            }
            // Check for game over.
            print("Game over.");
            _restartCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
