using UnityEngine;

namespace Player
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private float _offset;
        private float _currentHeight = float.NegativeInfinity;
        private float _highHeight = float.NegativeInfinity;

        public float GetHighHeight()
        {
            return _highHeight;
        }

        public int GetHighScore()
        {
            return Mathf.RoundToInt(_highHeight * 0.8f);
        }
        private void Update()
        {
            _currentHeight = transform.position.y + _offset;
            
            if (_currentHeight > _highHeight)
            {
                _highHeight = _currentHeight;
            }
        }
    }
}