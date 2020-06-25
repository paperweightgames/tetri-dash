using System.Collections.Generic;
using Palette;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PaletteDisplay : MonoBehaviour
    {
        [SerializeField] private Material _paletteMaterial;
        [SerializeField] private Text _valueText;
        [SerializeField] private PaletteObject _paletteObject;
        private List<int> _palettes;
        private int _currentPalette;
        private static readonly int PaletteTex = Shader.PropertyToID("_PaletteTex");

        private void OnEnable()
        {
            Revert();
            ChangeValue(0);
        }

        public void ChangeValue(int amount)
        {
            _currentPalette += amount;
            _currentPalette %= _palettes.Count;
            var paletteIndex = _palettes[_currentPalette];
            _valueText.text = _paletteObject.GetPalette(paletteIndex).name;
            UpdatePalette();
        }

        public void SavePalette()
        {
            SaveLoad.GameSave.SetActivePalette(_currentPalette);
            UpdatePalette();
            SaveLoad.Save();
        }

        public void Revert()
        {
            SaveLoad.Load();
            var saveGame = SaveLoad.GameSave;
            _palettes = saveGame.GetPalettes();
            _currentPalette = saveGame.GetActivePalette();
            UpdatePalette();
        }

        private void UpdatePalette()
        {
            var paletteIndex = _palettes[_currentPalette];
            var activeTexture = _paletteObject.GetPalette(paletteIndex).texture;
            _paletteMaterial.SetTexture(PaletteTex, activeTexture);
        }
    }
}
