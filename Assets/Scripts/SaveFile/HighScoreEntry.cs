using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SaveFile
{
    [Serializable]
    public class HighScoreEntry
    {
        [SerializeField] private string _name;
        [SerializeField] private string _level;
        [SerializeField] private float _score;

        public string GetName()
        {
            return _name;
        }

        public string GetLevel()
        {
            return _level;
        }

        public float GetScore()
        {
            return _score;
        }
    }
}