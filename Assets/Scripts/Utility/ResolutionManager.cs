using UnityEngine;

namespace Utility
{
    public class ResolutionManager : MonoBehaviour
    {
        [SerializeField] private string _pixelScaleKey;
        private Vector2Int _defaultResolution = new Vector2Int(384, 216);
        private int _pixelScale;

        private void Update()
        {
            // Get the current pixel scale.
            _pixelScale = PlayerPrefs.GetInt(_pixelScaleKey, 3);
            // Set the resolution based on the pixel scale.
            Screen.SetResolution(_defaultResolution.x * _pixelScale, _defaultResolution.y * _pixelScale,
                FullScreenMode.Windowed);
        }
    }
}