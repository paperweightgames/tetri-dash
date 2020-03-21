using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UiScaler : MonoBehaviour
    {
        [SerializeField] private string _key;
        private CanvasScaler _canvasScaler;

        private void Awake()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
        }

        private void Update()
        {
            _canvasScaler.scaleFactor = PlayerPrefs.GetInt(_key);
        }
    }
}