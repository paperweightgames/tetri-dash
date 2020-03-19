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

        private void Awake()
        {
            #if UNITY_IOS
                Destroy(gameObject);
            #endif
            #if UNITY_ANDROID
                Destroy(gameObject);
            #endif
            #if UNITY_WEBGL
                Destroy(gameObject);
            #endif
        }
    }
}