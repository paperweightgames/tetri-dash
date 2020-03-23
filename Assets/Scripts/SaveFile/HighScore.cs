using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SaveFile
{
    [Serializable]
    public class HighScore
    {
        [SerializeField] private Key[] _controls;
        [SerializeField] private float _height;
    }
}