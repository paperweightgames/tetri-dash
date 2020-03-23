using UnityEngine;

namespace UI
{
    public class CanvasAlign : MonoBehaviour
    {
        private void LateUpdate()
        {
            var newPosition = transform.position;
            newPosition.y = Mathf.Round(transform.position.y * 10) / 10;
            transform.position = newPosition;
        }
    }
}