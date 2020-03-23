using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class RandomHead : MonoBehaviour
    {
        [SerializeField] private Sprite[] _heads;

        private void Start()
        {
            var randomHeadIndex = Random.Range(0, _heads.Length);
            var randomHead = _heads[randomHeadIndex];
            GetComponent<SpriteRenderer>().sprite = randomHead;
        }
    }
}