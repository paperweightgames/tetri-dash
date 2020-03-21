using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class LoadScene : MonoBehaviour
    {
        public void Load(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}