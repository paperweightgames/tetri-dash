using System;
using System.Collections.Generic;
using SaveFile;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PaletteDisplay : MonoBehaviour
    {
        [SerializeField] private Material _paletteMaterial;
        [SerializeField] private Text _valueText;
        private SaveFileManager _saveFileManager;
        private List<Sprite> _palettes;
        private int _activePalette;
        private static readonly int PaletteTex = Shader.PropertyToID("_PaletteTex");

        private void OnEnable()
        {
            Revert();
            ChangeValue(0);
        }

        public void ChangeValue(int amount)
        {
            _activePalette += amount;
            _activePalette %= _palettes.Count;
            _valueText.text = _activePalette == 0 ? "default" : _palettes[_activePalette].name;
            UpdatePalette();
        }

        public void SavePalette()
        {
            _saveFileManager.GetActiveSaveFile().SetActivePalette(_activePalette);
            UpdatePalette();
        }

        public void Revert()
        {
            _saveFileManager = SaveFileManager.GetInstance();
            _palettes = _saveFileManager.GetActiveSaveFile().GetPalettes();
            _activePalette = _saveFileManager.GetActiveSaveFile().GetActivePalette();
        }

        private void UpdatePalette()
        {
            var activeTexture = _palettes[_activePalette].texture;
            _paletteMaterial.SetTexture(PaletteTex, activeTexture);
        }
    }
}
