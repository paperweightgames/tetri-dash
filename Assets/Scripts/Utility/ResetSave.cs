using UnityEngine;

namespace Utility
{
    public class ResetSave : MonoBehaviour
    {
        public void Reset()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}