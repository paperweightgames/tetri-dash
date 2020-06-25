using System.Collections.Generic;
using UnityEngine;

namespace Palette
{
    [CreateAssetMenu(fileName = "Palettes", menuName = "ScriptableObject/Palettes", order = 0)]
    public class PaletteObject : ScriptableObject
    {
        [SerializeField] private List<Sprite> _palettes;

        public Sprite GetPalette(int index)
        {
            return _palettes[index];
        }
    }
}