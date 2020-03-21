using System.Collections.Generic;
using UnityEngine;

namespace Player.Tracker
{
    public class HighestPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private Transform _minimumHeight;
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
            var newPosition = Vector3.down * 100f;
            foreach (var player in _playerList)
            {
                // Check if a player is higher than the highest point.
                if (player.position.y > newPosition.y)
                {

                    newPosition.y = player.position.y;
                }
            }

            newPosition.y = Mathf.Max(newPosition.y, _minimumHeight.position.y);

            transform.position = newPosition;
        }
    }
}