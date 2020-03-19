using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCape : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _speed;
        [SerializeField] private float _offset;
        [SerializeField] private int _capeLength;
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject _capePrefab;
        [SerializeField] private PlayerColour _playerColour;
        private List<Transform> _capeSegments = new List<Transform>();

        private void Start()
        {
            transform.position = Vector3.zero;
            SetLength(_capeLength);
        }

        private void Update()
        {
            transform.position = Vector3.zero;
            for (var s = 0; s < _capeSegments.Count; s++)
            {
                // Get the current position.
                var currentPosition = _capeSegments[s].position;
                // Get the position of the previous segment.
                var targetPosition = _player.position;
                if (s != 0)
                {
                    targetPosition = _capeSegments[s - 1].position + Vector3.up * _offset;
                }
                // Work out the smooth position.
                var newPosition = Vector2.Lerp(currentPosition, targetPosition, _speed);
                _capeSegments[s].position = newPosition;
            }
        }
        private void SetLength(int newLength)
        {
            // Delete the old cape.
            foreach (var segment in _capeSegments)
            {
                Destroy(segment);
            }
            _capeSegments.Clear();
            var capeColour = _playerColour.GetColour();
            // Create new cape.
            for (var s = 0; s < newLength; s++)
            {
                // Create a new cape segment.
                var newSegment = Instantiate(_capePrefab, _player.position, Quaternion.identity, transform);
                _capeSegments.Add(newSegment.transform);
                // Assign the colour.
                newSegment.GetComponent<SpriteRenderer>().color = capeColour;
            }
        }
    }
}