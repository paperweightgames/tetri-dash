using UnityEngine;

namespace Cam
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField, Range(0, 1)] private float _speed;
        [SerializeField] private Vector3 _offset;

        private void Update()
        {
            Vector3 targetPosition = Vector2.Lerp(transform.position, _targetTransform.position, _speed);
            targetPosition.x = 0;
            targetPosition.z = _offset.z;
            transform.position = targetPosition;
        }
    }
}
