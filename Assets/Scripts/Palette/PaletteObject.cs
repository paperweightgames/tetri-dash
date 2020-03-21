using UnityEngine;

[CreateAssetMenu(fileName = "Palette Object", menuName = "ScriptableObjects/PaletteObject", order = 0)]
public class PaletteObject : ScriptableObject
{
    [SerializeField] private Sprite[] _palettes;
    [SerializeField] private Material _material;
    private static readonly int PaletteTex = Shader.PropertyToID("_PaletteTex");

    public void SetPalette(int paletteIndex)
    {
        _material.SetTexture(PaletteTex, _palettes[paletteIndex].texture);
    }
}