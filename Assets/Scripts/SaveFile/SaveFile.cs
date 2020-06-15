﻿using System.Collections.Generic;
 using System.Linq;
 using UnityEngine;

namespace SaveFile
{
    [CreateAssetMenu(fileName = "Save File", menuName = "ScriptableObjects/SaveFile", order = 0)]
    public class SaveFile : ScriptableObject
    {
        [SerializeField] private List<HighScoreData> _highScores;
        [SerializeField] private List<Sprite> _palettes;
        [SerializeField] private List<Sprite> _heads;
        [SerializeField] private int _activePalette;

        public List<Sprite> GetPalettes()
        {
            return _palettes;
        }

        public int GetActivePalette()
        {
            return _activePalette;
        }

        public void SetActivePalette(int activePalette)
        {
            _activePalette = activePalette;
        }

        public List<Sprite> GetHeads()
        {
            return _heads;
        }

        public bool UnlockHead(Sprite newHead)
        {
            // Check if the head is already unlocked.
            if (_heads.Contains(newHead))
                return false;
            // Add the new head.
            _heads.Add(newHead);
            return true;
        }

        public bool IsHeadUnlocked(Sprite head)
        {
            return _heads.Contains(head);
        }

        public IEnumerable<HighScoreData> GetHighScores()
        {
            return _highScores;
        }

        public void AddHighScore(HighScoreData newHighScore)
        {
            _highScores.Add(newHighScore);
            // Sort by score.
            _highScores.Sort((x, y) => y.GetScore().CompareTo(x.GetScore()));
            // Remove duplicates.
            _highScores = _highScores.GroupBy(x => x.GetName()).Select(x => x.First()).ToList();
        }
    }
}