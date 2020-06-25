using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Saving
{
    [Serializable]
    public class GameSave
    {
        [SerializeField] private List<HighScoreData> _highScores;
        [SerializeField] private List<int> _palettes;
        [SerializeField] private List<int> _heads;
        [SerializeField] private int _activePalette;

        public List<HighScoreData> GetHighScores()
        {
            return _highScores;
        }
        public void AddHighScore(HighScoreData highScore)
        {
            _highScores.Add(highScore);
            // Sort by score.
            _highScores.Sort((x, y) => y.GetScore().CompareTo(x.GetScore()));
            // Remove duplicates.
            _highScores = _highScores.GroupBy(x => x.GetName()).Select(x => x.First()).ToList();
        }
        public int GetActivePalette()
        {
            return _activePalette;
        }
        public void SetActivePalette(int activePalette)
        {
            _activePalette = activePalette;
        }

        public void UnlockPalette(int palette)
        {
            if (_palettes.Contains(palette))
                return;
            _palettes.Add(palette);
        }

        public List<int> GetPalettes()
        {
            return _palettes;
        }
        public List<int> GetHeads()
        {
            return _heads;
        }

        public bool IsHeadUnlocked(int head)
        {
            return _heads.Contains(head);
        }

        public void UnlockHead(int head)
        {
            if (IsHeadUnlocked(head))
                return;
            _heads.Add(head);
        }

        public void Reset(List<int> palettes, List<int> heads, int activePalette = 0)
        {
            _highScores = new List<HighScoreData>();
            _palettes = palettes;
            _heads = heads;
            _activePalette = activePalette;
            SaveLoad.Save();
        }
    }
}