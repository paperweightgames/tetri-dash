using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetrominoes
{
    public class TetriminoeManager : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 1;
        [SerializeField] private float _fallVelocity;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _acceleration;
        [SerializeField] private int _moveAttempts = 2;
        [SerializeField] private int _xSpread;
        [SerializeField] private Vector2Int _ySpread;
        [SerializeField] private TetriminoePalette _tetriminoePalette;
        [SerializeField] private Rigidbody2D _smoothFall;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _highestTetriminoe;
        private readonly List<Collider2D> _results = new List<Collider2D>();
        private readonly ContactFilter2D _contactFilter = new ContactFilter2D();
        private Grid _grid;
        private float _playTime;
        private float _timeSinceSpawn;
        private int _attempts;

        private void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        private void Start()
        {
            _smoothFall.velocity = Vector2.down * _fallVelocity;
            _timeSinceSpawn = _spawnInterval;
        }

        private void Update()
        {
            // Keep track of time passed.
            _playTime += Time.deltaTime;
            // Update the speed of the tetrominoes.
            _fallVelocity = _playTime / _acceleration + 0.8f;
            _fallVelocity = Mathf.Clamp(_fallVelocity, 0, 8);
            _smoothFall.velocity = Vector2.down * _fallVelocity;
            
            if (_timeSinceSpawn >= _spawnInterval)
            {
                // Don't spawn if too far ahead.
                var distance = Mathf.Abs(_highestTetriminoe.position.y - _cameraTransform.position.y);
                if (distance > _maxDistance) return;
                // Spawn the tetriminoe.
                _timeSinceSpawn = 0;
                SpawnTetriminoe();
            }
            else
            {
                _timeSinceSpawn += Time.deltaTime;
            }
        }

        private void SpawnTetriminoe()
        {
            // Choose a new tetriminoe to spawn.
            var tetriminoes = _tetriminoePalette.GetTetriminoes();
            var randomTetriminoeIndex = Random.Range(0, tetriminoes.Length);
            var randomTetriminoe = tetriminoes[randomTetriminoeIndex];
            // Create a new tetriminoe.
            var newTetriminoe = Instantiate(randomTetriminoe, GetRandomSpawnPosition(), Quaternion.identity, _smoothFall.transform);
            _attempts = 0;
            while (_attempts < _moveAttempts)
            {
                if (IsTetriminoeClear(newTetriminoe))
                {
                    // Set new tetromino as highest.
                    if (newTetriminoe.transform.position.y > _highestTetriminoe.position.y)
                    {
                        var newPosition = Vector3.up * newTetriminoe.transform.position.y;
                        _highestTetriminoe.position = newPosition;
                    }
                    return;
                }
                newTetriminoe.transform.position = GetRandomSpawnPosition();
                _attempts++;
            }
            // Destroy the tetriminoe if it isn't clear.
            Destroy(newTetriminoe);
        }

        private Vector2 GetRandomSpawnPosition()
        {
            var randomX = Random.Range(-_xSpread, _xSpread + 1);
            var randomY = Random.Range(_ySpread.x, _ySpread.y);
            var cellSize = _grid.cellSize;
            var randomPosition = new Vector2(randomX, randomY) * cellSize;
            var offsetPosition = new Vector3(transform.position.x, _highestTetriminoe.position.y);
            var roundedYPosition = Mathf.Round(offsetPosition.y / cellSize.y) * _grid.cellSize.y;
            randomPosition += new Vector2(offsetPosition.x, roundedYPosition);
            return randomPosition;
        }

        private bool IsTetriminoeClear(GameObject tetriminoe)
        {
            var tetriminoeCollider = tetriminoe.GetComponent<CompositeCollider2D>();
            _results.Clear();
            if (Physics2D.OverlapCollider(tetriminoeCollider, _contactFilter, _results) <= 0) return true;
            foreach (var col in _results)
            {
                if (col.CompareTag("Tetriminoe")) return false;
            }

            return true;
        }
    }
}