using System;
using UnityEngine;

namespace Cam
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField, Range(0, 1)] private float _speed;
        [SerializeField] private Vector3 _offset;
        private Vector3 _currentPosition;

        private void Start()
        {
            _currentPosition = transform.position;
        }

        private void Update()
        {
            // Work out the new position of the camera.
            Vector3 targetPosition = Vector2.Lerp(_currentPosition, _targetTransform.position, _speed);
            targetPosition.x = 0;
            targetPosition.z = _offset.z;
            _currentPosition = targetPosition;
            // Round the position.
            var roundedPosition = _currentPosition;
            roundedPosition.y = Mathf.Round(roundedPosition.y * 10) / 10;
            transform.position = roundedPosition;
        }
    }
}
