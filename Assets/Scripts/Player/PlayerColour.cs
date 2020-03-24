using UnityEngine;

namespace Player
{
    public class PlayerColour : MonoBehaviour
    {
        [SerializeField] private Color _colour;
        [SerializeField] private ParticleSystem _particleSystem;

        public Color GetColour()
        {
            return _colour;
        }

        public void SetColour(Color newColour)
        {
            _colour = newColour;
            var main = _particleSystem.main;
            main.startColor = _colour;
        }
    }
}