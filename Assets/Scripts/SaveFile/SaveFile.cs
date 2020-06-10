﻿using System.Collections.Generic;
 using UnityEngine;

namespace SaveFile
{
    [CreateAssetMenu(fileName = "Save File", menuName = "ScriptableObjects/SaveFile", order = 0)]
    public class SaveFile : ScriptableObject
    {
        [SerializeField] private List<string> _levels;
        [SerializeField] private List<Sprite> _palettes;
        [SerializeField] private List<Sprite> _heads;
        [SerializeField] private List<HighScoreEntry> _highScores;
        [SerializeField] private float _timeSpent;
        [SerializeField] private int _activePalette;

        public List<string> GetLevels()
        {
            return _levels;
        }

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

        public void UnlockLevel(string levelName)
        {
            // Check if the level is already unlocked.
            if (_levels.Contains(levelName)) return;
            // Add the new level.
            _levels.Add(levelName);
        }

        public bool IsLevelUnlocked(string levelName)
        {
            return _levels.Contains(levelName);
        }

        public List<Sprite> GetHeads()
        {
            return _heads;
        }

        public void UnlockHead(Sprite newHead)
        {
            // Check if the head is already unlocked.
            if (_heads.Contains(newHead)) return;
            // Add the new head.
            _heads.Add(newHead);
        }

        public bool IsHeadUnlocked(Sprite head)
        {
            return _heads.Contains(head);
        }

        public void AddHighScore(HighScoreEntry highScoreEntry)
        {
            _highScores.Add(highScoreEntry);
        }

        public IEnumerable<HighScoreEntry> GetHighScores(string levelName)
        {
            return _highScores.FindAll(item => item.GetLevel() == levelName);
        }
    }
}