using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace SaveSystem
{
    public class SaveManager
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        //
        #region SAVE DATA ACCESSORS
        // put accessors here
        #endregion

        string[] _saveFiles;

        private static readonly string _localSaveDirectory = "/saves/";
        private static readonly string _extension = ".sav";

        public static string GetSaveDirectory()
        {
            return Application.persistentDataPath + _localSaveDirectory;
        }

        public static string GetSaveFilePath(string fileName)
        {
            return Application.persistentDataPath + _localSaveDirectory + fileName + _extension;
        }


        private SaveManager()
        {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
            Debug.Log("Save File Path: " + Application.persistentDataPath);
        }

        public void Save(string fileName)
        {
            _jsonSaver.Save(_saveData, GetSaveFilePath(fileName));
            Debug.Log("Data Saved");
        }

        // filename without extension - example: AdamsFile, NOT AdamsFile.sav
        public void Load(string fileName)
        {
            _jsonSaver.Load(_saveData, GetSaveFilePath(fileName));
            Debug.Log("Data Loaded");
        }

        public void GetLoadFiles()
        {
            string targetDirectory = GetSaveDirectory();
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            _saveFiles = Directory.GetFiles(targetDirectory);
        }
    }
}

