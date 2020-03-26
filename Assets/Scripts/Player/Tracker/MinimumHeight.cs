using UnityEngine;

namespace Player.Tracker
{
    public class MinimumHeight : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;

        private void Update()
        {
            // speed up the tracker.
            _speed += _acceleration * Time.deltaTime;
            _speed = Mathf.Min(_speed, _maxSpeed);
            transform.position += Time.deltaTime * _speed * Vector3.up;
        }
    }
}