using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class ReloadScene : MonoBehaviour
    {
        public void Reload()
        {
            Time.timeScale = 1;
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
