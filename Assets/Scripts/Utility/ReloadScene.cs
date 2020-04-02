using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class ReloadScene : MonoBehaviour
    {
        public void Reload()
        {
            Time.timeScale = 1;
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }
}
