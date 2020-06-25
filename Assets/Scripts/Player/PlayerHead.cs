using System.Collections.Generic;
using Saving;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerHead : MonoBehaviour
    {
        [SerializeField] private HeadObject _headObject;
        private List<int> _heads;
        private SpriteRenderer _spriteRenderer;
        private int _currentHead;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _heads = SaveLoad.GameSave.GetHeads();
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
            var headIndex = _heads[_currentHead];
            _spriteRenderer.sprite = _headObject.GetHead(headIndex);
        }

        public void NextHead()
        {
            _currentHead++;
            _currentHead %= _heads.Count;
            UpdateHead();
        }
    }
}