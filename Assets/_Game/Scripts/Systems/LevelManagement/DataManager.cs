using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTTK.Data
{
    public class DataManager
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        //
        #region SAVE DATA ACCESSORS
        // put accessors here
        #endregion

        private DataManager()
        {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
            Debug.Log("Save File Path: " + Application.persistentDataPath);
        }

        public void Save(SaveData saveData)
        {
            _jsonSaver.Save(_saveData);
            Debug.Log("Data Saved");
        }

        public void Load()
        {
            _jsonSaver.Load(_saveData);
            Debug.Log("Data Loaded");
        }
    }
}

