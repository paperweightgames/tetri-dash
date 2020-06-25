using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Heads", menuName = "ScriptableObject/Heads", order = 0)]
    public class HeadObject : ScriptableObject
    {
        [SerializeField] private List<Sprite> _heads;

        public Sprite GetHead(int index)
        {
            return _heads[index];
        }
    }
}