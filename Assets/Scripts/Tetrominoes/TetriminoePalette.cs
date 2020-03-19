﻿using UnityEngine;

namespace Tetrominoes
{
    [CreateAssetMenu(fileName = "Tetriminoe Palette", menuName = "ScriptableObject/TetriminoePalette", order = 0)]
    public class TetriminoePalette : ScriptableObject
    {
        [SerializeField] private GameObject[] _tetriminoePrefabs;

        public GameObject[] GetTetriminoes()
        {
            return _tetriminoePrefabs;
        }
    }
}
