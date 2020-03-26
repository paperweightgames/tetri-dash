using UnityEngine;

namespace UI
{
    public class OpenLink : MonoBehaviour
    {
        public void OpenURLLink(string link)
        {
            #if UNITY_WEBGL
                return;
            #endif
            Application.OpenURL(link);
        }
    }
}