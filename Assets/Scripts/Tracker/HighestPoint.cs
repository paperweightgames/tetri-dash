using UnityEngine;

namespace Player.Tracker
{
    public class HighestPoint : MonoBehaviour
    {
        [SerializeField] private Transform _tracker;

        private void Update()
        {
            // If the tracker is above.
            if (_tracker.position.y > transform.position.y)
            {
                transform.position = Vector3.up * _tracker.position.y;
            }
        }
    }
}