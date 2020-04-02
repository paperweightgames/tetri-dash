using UnityEngine;

namespace UI
{
    public class StandaloneShow : MonoBehaviour
    {
        private void Awake()
        {
            #if UNITY_STANDALONE
                return;
            #else
            // Destroy all game objects.
                gameObject.SetActive(false);
            #endif
        }
    }
}