using UnityEngine;
using Random = UnityEngine.Random;

namespace Utility
{
    public class ScreenShake : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _intensity;
        [SerializeField] private AnimationCurve _dropoff;
        [SerializeField] private Transform _camera;
        private Vector2 _offset;

        private void Update()
        {
            // Stop if below 0.
            if (_duration <= 0)
            {
                _offset = Vector2.zero;
                _duration = 0;
                return;
            }
            _duration -= Time.deltaTime;
            var intensity = _dropoff.Evaluate(_duration) * _intensity;
            var xPos = Random.Range(-intensity, intensity);
            var yPos = Random.Range(-intensity, intensity);
            _offset = new Vector2(xPos, yPos);
            _camera.localPosition = _offset;
        }

        public void SetDuration(float duration)
        {
            _duration = duration;
        }
    }
}