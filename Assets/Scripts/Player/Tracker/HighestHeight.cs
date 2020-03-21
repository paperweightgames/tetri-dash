using System.Collections.Generic;
using UnityEngine;

namespace Player.Tracker
{
    public class HighestHeight : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        private readonly List<Transform> _playerList = new List<Transform>();

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
            foreach (var player in _playerList)
            {
                // Check if a player is higher than the highest point.
                if (player.position.y > transform.position.y)
                {
                    var newPosition = Vector3.up * player.position.y;
                    transform.position = newPosition;
                }
            }
        }
    }
}