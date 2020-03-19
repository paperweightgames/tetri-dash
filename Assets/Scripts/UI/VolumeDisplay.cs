using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VolumeDisplay : MonoBehaviour
    {
        [SerializeField] private string _key;
        [SerializeField] private int _maxValue = 10;
        [SerializeField] private int _defaultValue = 10;
        [SerializeField] private Text _valueText;
        private int _value;

        private void OnEnable()
        {
            LoadValue();
            ChangeValue(0);
        }

        private void LoadValue()
        {
            _value = PlayerPrefs.GetInt(_key, _defaultValue);
        }

        public void SaveValue()
        {
            PlayerPrefs.SetInt(_key, _value);
        }

        public void SetValue(int newValue)
        {
            _value = newValue;
            ChangeValue(0);
        }

        public void ChangeValue(int amount)
        {
            _value += amount;
            _value = Mathf.Clamp(_value, 0, _maxValue);
            _valueText.text = _value.ToString();
        }
    }
}