using UnityEngine;

namespace Tetrominoes.SmoothFall
{
    public class FallCheck : MonoBehaviour
    {
        private Transform _parent;

        private void Awake()
        {
            _parent = transform.parent;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform == _parent) return;
            if (!other.CompareTag("Tetriminoe")) return;
            
            _parent.parent = GetComponentInParent<Grid>().transform;
            AlignPosition();
        }

        private void AlignPosition()
        {
            var tPosition = _parent.position;
            var xPosition = Mathf.Round(tPosition.x / 0.8f) * 0.8f;
            var yPosition = Mathf.Round(tPosition.y / 0.8f) * 0.8f;
            _parent.position = new Vector3(xPosition, yPosition, 0);
        }
    }
}