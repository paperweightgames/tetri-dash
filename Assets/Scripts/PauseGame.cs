using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUi;
    private bool _isPaused;

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
        _pauseUi.SetActive(_isPaused);
    }
}