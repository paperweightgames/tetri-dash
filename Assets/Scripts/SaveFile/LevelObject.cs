using UnityEngine;

namespace SaveFile
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 0)]
    public class LevelObject : ScriptableObject
    {
        [SerializeField] private string _levelName;
        [SerializeField] private int _defaultPalette;
        [SerializeField] private HighScore[] _highScores;
    }
}