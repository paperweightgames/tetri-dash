using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saving
{
    public static class SaveLoad
    {
        private static readonly string FilePath = $"{Application.persistentDataPath}/gameSave.td";
        public static GameSave GameSave = new GameSave();

        public static string GetFilePath()
        {
            return FilePath;
        }

        public static void Save()
        {
            var bf = new BinaryFormatter();
            var file = File.Create(FilePath);
            bf.Serialize(file, GameSave);
            file.Close();
        }

        public static bool Load()
        {
            // Stop if the file doesn't exist.
            if (!File.Exists(FilePath))
                return false;
            var bf = new BinaryFormatter();
            var file = File.Open(FilePath, FileMode.Open);
            GameSave = (GameSave) bf.Deserialize(file);
            file.Close();
            return true;
        }
    }
}