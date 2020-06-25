using System;
using UnityEngine;

namespace Saving
{
    [Serializable]
    public class HighScoreData
    {
        [SerializeField] private string _name;
        [SerializeField] private float _height;

        public HighScoreData(string name, float height)
        {
            _name = name;
            _height = height;
        }

        public string GetName()
        {
            return _name;
        }
        public float GetScore()
        {
            return _height;
        }
    }
}