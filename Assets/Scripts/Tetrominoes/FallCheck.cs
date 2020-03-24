using UnityEngine;

namespace Tetrominoes
{
    public class FallCheck : MonoBehaviour
    {
        private Transform _parent;
        private Transform _originalTransform;
        private Collider2D _other;

        private void Awake()
        {
            _parent = transform.parent;
            _originalTransform = _parent.parent;
        }

        private void FixedUpdate()
        {
            // Check if the block below had been destroyed.
            if (_other == null) return;
            _parent.parent = _originalTransform;
            AlignPosition();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Ignore self.
            if (other.transform == _parent) return;
            if (!other.CompareTag("Tetriminoe")) return;
            // if (other.bounds.min.y > )
            _other = other;
            
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