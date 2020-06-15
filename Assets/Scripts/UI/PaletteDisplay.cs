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
            _activePalette = Mathf.Clamp(_activePalette, 0, _palettes.Count - 1);
            _valueText.text = _palettes[_activePalette].name;
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
            UpdatePalette();
        }

        private void UpdatePalette()
        {
            var activeTexture = _palettes[_activePalette].texture;
            _paletteMaterial.SetTexture(PaletteTex, activeTexture);
        }
    }
}
