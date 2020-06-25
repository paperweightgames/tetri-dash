using System.Collections.Generic;
using UnityEngine;

namespace Saving
{
    public class SaveLoader : MonoBehaviour
    {
        [SerializeField] private List<int> _defaultPalettes;
        [SerializeField] private List<int> _defaultHeads;

        private void Awake()
        {
            // Reset if a save file doesn't exist.
            if (!SaveLoad.Load())
                Reset();
        }

        public void Reset()
        {
            SaveLoad.GameSave.Reset(_defaultPalettes, _defaultHeads);
        }
    }
}