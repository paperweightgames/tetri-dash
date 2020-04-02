using System;
using System.Collections.Generic;
using SaveFile;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerHead : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _heads;
        private SpriteRenderer _spriteRenderer;
        private int _currentHead;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _heads = SaveFileManager.GetInstance().GetActiveSaveFile().GetHeads();
        }

        private void Start()
        {
            SetRandomHead();
        }

        private void SetRandomHead()
        {
            _currentHead = Random.Range(0, _heads.Count);
            UpdateHead();
        }

        private void UpdateHead()
        {
            var randomHead = _heads[_currentHead];
            _spriteRenderer.sprite = randomHead;
        }

        public void NextHead()
        {
            _currentHead++;
            if (_currentHead >= _heads.Count)
            {
                _currentHead = 0;
            }
            UpdateHead();
        }
    }
}