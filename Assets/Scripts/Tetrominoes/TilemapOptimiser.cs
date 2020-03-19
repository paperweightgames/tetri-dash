using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
    [RequireComponent(typeof(Tilemap)), ExecuteInEditMode]
    public class TilemapOptimiser : MonoBehaviour
    {
        private void Awake()
        {
            var tilemap = GetComponent<Tilemap>();
            tilemap.CompressBounds();
        }
    }
}
