using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelName : MonoBehaviour
    {
        private void Awake()
        {
            var text = GetComponent<Text>();
            var levelName = SceneManager.GetActiveScene().name;
            text.text = levelName;
        }
    }
}