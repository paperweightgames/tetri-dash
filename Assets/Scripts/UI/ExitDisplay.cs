using UnityEditor;
using UnityEngine;

namespace UI
{
    public class ExitDisplay : MonoBehaviour
    {
        public void ExitGame()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #endif
            #if UNITY_STANDALONE
                Application.Quit();
            #endif
        }
    }
}