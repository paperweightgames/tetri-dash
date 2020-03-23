using UnityEngine;

public class LevelHighScore : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private string _prefsKey;

    public float GetHight()
    {
        return PlayerPrefs.GetFloat(string.Format(_prefsKey, _levelName), 0);
    }

    public void SetHight(float newHeight)
    {
        PlayerPrefs.SetFloat(string.Format(_prefsKey, _levelName), newHeight);
    }
}