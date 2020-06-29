using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InputDisplay : MonoBehaviour
    {
        [SerializeField] private string[] _prompts;
        private int _currentPrompt;
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            UpdatePrompt();
        }

        private void UpdatePrompt()
        {
            _text.text = _prompts[_currentPrompt];
        }

        public void AdvancePrompt(int amount)
        {
            _currentPrompt += amount;
            _currentPrompt = (int)Mathf.Repeat(_currentPrompt, _prompts.Length);
            UpdatePrompt();
        }
    }
}