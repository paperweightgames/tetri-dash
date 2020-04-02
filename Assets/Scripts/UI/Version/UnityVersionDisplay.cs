using UnityEngine;
using UnityEngine.UI;

namespace UI.Version
{
    public class UnityVersionDisplay : MonoBehaviour
    {
        private void Awake()
        {
            var text = GetComponent<Text>();
            text.text = $"unity v: {Application.unityVersion}";
        }
    }
}