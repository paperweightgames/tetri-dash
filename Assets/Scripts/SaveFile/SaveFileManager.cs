using System.Collections.Generic;
using UnityEngine;

namespace SaveFile
{
    public class SaveFileManager : MonoBehaviour
    {
        [SerializeField] private List<SaveFile> _saveFiles;
        [SerializeField] private int _activeSaveFile;
        private static SaveFileManager _instance;

        public static SaveFileManager GetInstance()
        {
            return _instance;
        }
        
        public void ChangeActiveSaveFile(int saveFileIndex)
        {
            _activeSaveFile = saveFileIndex;
            _activeSaveFile = Mathf.Clamp(_activeSaveFile, 0, _saveFiles.Count - 1);
        }

        public SaveFile GetActiveSaveFile()
        {
            return _saveFiles[_activeSaveFile];
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}