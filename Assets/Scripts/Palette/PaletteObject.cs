using UnityEngine;

namespace Palette
{
    [CreateAssetMenu(fileName = "Palette Object", menuName = "ScriptableObjects/PaletteObject", order = 0)]
    public class PaletteObject : ScriptableObject
    {
        [SerializeField] private string _prefsKey;
        [SerializeField] private Texture2D[] _palettes;
        [SerializeField] private Material _material;
        private static readonly int PaletteTex = Shader.PropertyToID("_PaletteTex");

        public void SetPalette(int paletteIndex)
        {
            var clampedIndex = Mathf.Clamp(paletteIndex, 0, _palettes.Length - 1);
            _material.SetTexture(PaletteTex, _palettes[clampedIndex]);
        }

        public void UpdatePalette()
        {
            var paletteIndex = PlayerPrefs.GetInt(_prefsKey, 0);
            SetPalette(paletteIndex);
        }
    }
}