using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeDisplay : MonoBehaviour
    {
        private Text _text;
        private float _timeSinceStart;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _timeSinceStart += Time.deltaTime;
            var minutes = Mathf.FloorToInt(_timeSinceStart / 60);
            var seconds = Mathf.FloorToInt(_timeSinceStart % 60);
            var fraction = (_timeSinceStart - (int) _timeSinceStart) * 1000;
            //_text.text = $"time: {minutes:00}:{seconds:00}:{fraction:000}";
            _text.text = $"time: {minutes:00}:{seconds:00}";
        }
    }
}