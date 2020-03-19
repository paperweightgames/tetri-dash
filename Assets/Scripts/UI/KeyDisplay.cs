using KeySubstitution;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class KeyDisplay : MonoBehaviour
    {
        [SerializeField] private Key _key;
        [SerializeField] private KeyNameObject _keyNameObject;
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = _keyNameObject.FormatKey(_key);
        }
    }
}