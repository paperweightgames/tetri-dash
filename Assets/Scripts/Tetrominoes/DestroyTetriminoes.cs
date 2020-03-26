using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
    public class DestroyTetriminoes : MonoBehaviour
    {
        private CircleCollider2D _circle;

        private void Awake()
        {
            _circle = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if object has a tilemap.
            var tilemap = other.GetComponent<Tilemap>();
            if (!tilemap) return;
            // Get all tiles in the radius.
            var position = tilemap.WorldToCell(transform.position);
            var intRadius = Mathf.CeilToInt(_circle.radius);
            var tilesToRemove = new List<Vector3Int>();
            for (var y = -intRadius; y < intRadius; y++)
            {
                for (var x = -intRadius; x < intRadius; x++)
                {
                    var offset = new Vector3Int(x, y, 0);
                    if (tilemap.GetTile(position + offset))
                    {
                        tilesToRemove.Add(position + offset);
                    }
                }
            }
                
            tilemap.SetTiles(tilesToRemove.ToArray(), new TileBase[tilesToRemove.Count]);
            if (tilemap.GetUsedTilesCount() <= 0)
            {
                Destroy(tilemap.gameObject);
            }
        }
    }
}