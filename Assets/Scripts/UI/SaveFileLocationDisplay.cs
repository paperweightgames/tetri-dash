using System;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SaveFileLocationDisplay : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Text>().text = $"save location: {SaveLoad.GetFilePath()}".ToLower();
        }
    }
}