using System.Collections.Generic;
using UnityEngine;

namespace SaveFile
{
    [CreateAssetMenu(fileName = "Level List", menuName = "ScriptableObjects/LevelList", order = 0)]
    public class LevelList : ScriptableObject
    {
        [SerializeField] private List<string> _levels;

        public List<string> GetLevels()
        {
            return _levels;
        }
    }
}