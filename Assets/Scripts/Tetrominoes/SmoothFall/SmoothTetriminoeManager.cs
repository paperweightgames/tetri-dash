﻿using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetrominoes.SmoothFall
{
    public class SmoothTetriminoeManager : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 1;
        [SerializeField] private Vector3 _fallVelocity;
        [SerializeField] private int _moveAttempts = 2;
        [SerializeField] private Vector2Int _spawnSpread;
        [SerializeField] private TetriminoePalette _tetriminoePalette;
        [SerializeField] private Vector3 _highestTetriminoe;
        [SerializeField] private SmoothFall _smoothFall;
        private readonly List<Collider2D> _results = new List<Collider2D>();
        private readonly ContactFilter2D _contactFilter = new ContactFilter2D();
        private Grid _grid;
        private float _timeSinceSpawn;
        private int _attempts;

        private void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        private void Start()
        {
            _smoothFall.SetVelocity(_fallVelocity);
        }

        private void Update()
        {
            if (_timeSinceSpawn >= _spawnInterval)
            {
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
            var randomTetriminoeIndex = Random.Range(1, tetriminoes.Length);
            var randomTetriminoe = tetriminoes[randomTetriminoeIndex];
            // Create a new tetriminoe.
            var newTetriminoe = Instantiate(randomTetriminoe, GetRandomSpawnPosition(), Quaternion.identity, _smoothFall.transform);
            _attempts = 0;
            while (_attempts < _moveAttempts)
            {
                if (IsTetriminoeClear(newTetriminoe))
                {
                    _highestTetriminoe = newTetriminoe.transform.position;
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
            var randomX = Random.Range(-_spawnSpread.x, _spawnSpread.x + 1);
            var randomY = Random.Range(0, _spawnSpread.y);
            var cellSize = _grid.cellSize;
            var randomPosition = new Vector2(randomX, randomY) * cellSize;
            var offsetPosition = Vector3.up * _highestTetriminoe.y;
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