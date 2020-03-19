using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VersionDisplay : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _text.text = $"version: {Application.version}";
        }
    }
}