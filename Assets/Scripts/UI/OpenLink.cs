using UnityEngine;

namespace UI
{
    public class OpenLink : MonoBehaviour
    {
        public void OpenURLLink(string link)
        {
            Application.OpenURL(link);
        }
    }
}