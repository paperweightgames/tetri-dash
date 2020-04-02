using UnityEngine;
using UnityEngine.UI;

namespace UI.Version
{
    public class GameVersionDisplay : MonoBehaviour
    {
        private void Awake()
        {
            var text = GetComponent<Text>();
            text.text = $"game v: {Application.version}";
        }
    }
}