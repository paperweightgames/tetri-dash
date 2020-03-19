using UnityEngine;

namespace Tetrominoes
{
    public class TetrominoeObject : MonoBehaviour
    {
        private Grid _grid;
        private FallCheck _fallCheck;
        private Rigidbody2D _rb;
        private int _attempts;

        public int GetAttempts()
        {
            return _attempts;
        }
        private void Awake()
        {
            _grid = GetComponentInParent<Grid>();
            _fallCheck = GetComponentInChildren<FallCheck>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Fall()
        {
            // Only fall if the space below is clear.
            if (!_fallCheck.IsClear())
            {
                _attempts++;
                return;
            }

            _attempts = 0;
            // Find the amount to fall.
            var fallAmount = _grid.cellSize.y;
            var newPosition = transform.position + Vector3.down * fallAmount;
            _rb.MovePosition(newPosition);
        }
    }
}