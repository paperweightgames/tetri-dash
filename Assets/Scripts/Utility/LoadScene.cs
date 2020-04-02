using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class LoadScene : MonoBehaviour
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}