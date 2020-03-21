using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FpsDisplay : MonoBehaviour
    {
        [SerializeField] private float _updateInterval;
        private float _timeSinceUpdate;
        private Text _text;
        private List<float> _deltaTimes = new List<float>();

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            if (_timeSinceUpdate >= _updateInterval)
            {
                var averageTime = _deltaTimes[0];
                for (var i = 1; i < _deltaTimes.Count; i++)
                {
                    averageTime = Mathf.Lerp(averageTime, _deltaTimes[i], .5f);
                }
                var fps = Mathf.RoundToInt(1 / averageTime);
                _text.text = $"fps: {fps:000}";
                _timeSinceUpdate = 0;
                _deltaTimes.Clear();
            }
            else
            {
                _deltaTimes.Add(Time.unscaledDeltaTime);
                _timeSinceUpdate += Time.unscaledDeltaTime;
            }
        }
    }
}