using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetrominoes
{
    public class TetrominoeManager : MonoBehaviour
    {
        [SerializeField] private List<TetrominoeObject> _tetriminoes;
        [SerializeField] private float _fallInterval = 1;
        [SerializeField] private TetriminoePalette _tetriminoePalette;
        [SerializeField] private Vector2Int _spawnSpread;
        [SerializeField] private int _spawnOffset;
        [SerializeField] private int _spawnAttempts;
        [SerializeField] private int _fallAttempts;
        [SerializeField] private Transform _offset;
        private float _timeSinceFall;
        private Grid _grid;

        private void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        private void Update()
        {
            if (_timeSinceFall < _fallInterval)
            {
                _timeSinceFall += Time.deltaTime;
                return;
            }
            _timeSinceFall = 0;
            
            // Remove deleted tetriminoes.
            _tetriminoes.RemoveAll(item => item == null);
            // Spawn a new tetriminoe.
            SpawnTetriminoe();
            // Move all the tetriminoes down.
            for (var i = 0; i < _tetriminoes.Count; i++)
            {
                var tetriminoe = _tetriminoes[i];
                if (tetriminoe.GetAttempts() > _fallAttempts)
                {
                    _tetriminoes[i] = null;
                }
                else
                {
                    tetriminoe.Fall();
                }
            }
        }

        private void SpawnTetriminoe()
        {
            // Choose a new tetriminoe to spawn.
            var tetriminoes = _tetriminoePalette.GetTetriminoes();
            var randomTetrominoeIndex = Random.Range(0, tetriminoes.Length);
            var randomTetrominoe = tetriminoes[randomTetrominoeIndex];
            var newTetriminoe = Instantiate(randomTetrominoe, GetRandomPosition(), Quaternion.identity, transform);
            var tCollider = newTetriminoe.GetComponent<Collider2D>();
            
            var attempts = 0;
            while (attempts < _spawnAttempts)
            {
                if (IsTetrominoeClear(tCollider))
                {
                    _tetriminoes.Add(newTetriminoe.GetComponent<TetrominoeObject>());
                    return;
                }

                newTetriminoe.transform.position = GetRandomPosition();
                attempts++;
            }
            Destroy(newTetriminoe);
        }

        private Vector2 GetRandomPosition()
        {
            // Pick a random location.
            var randomX = Random.Range(-_spawnSpread.x, _spawnSpread.x + 1);
            var randomY = Random.Range(-_spawnSpread.y, _spawnSpread.y) + _spawnOffset + Mathf.RoundToInt(_offset.position.y / _grid.cellSize.y);
            var randomPosition = new Vector2(randomX, randomY) * _grid.cellSize;
            return randomPosition;
        }

        private bool IsTetrominoeClear(Collider2D tetrominoe)
        {
            var results = new List<Collider2D>();
            // Return true if no colliders are overlapping.
            if (Physics2D.OverlapCollider(tetrominoe, new ContactFilter2D(), results) <= 0) return true;
            foreach (var col in results)
            {
                // Ignore triggers.
                if (col.isTrigger) continue;
                return false;
            }

            return true;
        }
    }
}