using System.Collections.Generic;
using Player;
using UnityEngine;

public class CenterHeight : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private Transform _minimumHeight;
    private List<Transform> _playerList = new List<Transform>();

    private void OnEnable()
    {
        UpdatePlayers();
    }

    public void UpdatePlayers()
    {
        _playerList.Clear();
        foreach (var player in _playerManager.GetPlayers())
        {
            _playerList.Add(player.transform);
        }
    }

    private void Update()
    {
        var targetPosition = Vector3.up * _playerList[0].position.y;
        for (var i = 1; i < _playerList.Count; i++)
        {
            var playerPosition = Vector3.up * _playerList[i].position.y;
            targetPosition = Vector3.Lerp(targetPosition, playerPosition, 0.5f);
        }

        targetPosition.y = Mathf.Max(targetPosition.y, _minimumHeight.position.y);

        transform.position = targetPosition;
    }
}