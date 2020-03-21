using UnityEngine;

namespace UI
{
    public class HidePixelScale : MonoBehaviour
    {
        private void Awake()
        {
            #if UNITY_STANDALONE
                return;
            #else
                Destroy(gameObject);
            #endif
        }
    }
}