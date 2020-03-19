using UnityEngine;

namespace Player
{
    public class PlayerColour : MonoBehaviour
    {
        [SerializeField] private Color _colour;

        public Color GetColour()
        {
            return _colour;
        }

        public void SetColour(Color newColour)
        {
            _colour = newColour;
        }
    }
}