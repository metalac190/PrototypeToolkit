using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Based on Wilmer Lin's Level Management in Unity tutorial
/// </summary>
namespace PTTK.Data
{
    public class JsonSaver
    {
        private static readonly string _filename = "saveData01.sav";
        public static string GetSaveFilename()
        {
            return Application.persistentDataPath + "/" + _filename;
        }

        public void Save(SaveData data)
        {
            data.HashValue = String.Empty;
            
            string json = JsonUtility.ToJson(data);
            // convert json to Hash and reoutput
            data.HashValue = GetSHA256(json);
            json = JsonUtility.ToJson(data);

            string saveFilename = GetSaveFilename();
            // create file on disk
            FileStream fileStream = new FileStream(saveFilename, FileMode.Create);
            // write json to file
            using(StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public bool Load(SaveData data)
        {
            string loadFilename = GetSaveFilename();
            // if we find it, read from file
            if (File.Exists(loadFilename))
            {
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    string json = reader.ReadToEnd();
                    // check hash before reading

                    if (CheckData(json))
                    {
                        Debug.Log("hashes are equal");
                    }
                    else
                    {
                        Debug.Log("JSONSAVER Load: invalid hash. Aborting file read...");
                    }

                    JsonUtility.FromJsonOverwrite(json, data);
                }
                return true;
            }

            return false;
        }

        private bool CheckData(string json)
        {
            // get json from a temporary, duplicate save file
            SaveData tempSaveData = new SaveData();
            JsonUtility.FromJsonOverwrite(json, tempSaveData);
            // hold on to old hash value, clear for new calculation
            string oldHash = tempSaveData.HashValue;
            tempSaveData.HashValue = String.Empty;
            // calculate a new hash value for comparison
            string tempJson = JsonUtility.ToJson(tempSaveData);
            string newHash = GetSHA256(tempJson);
            // if they're the same, check is successful!
            return (oldHash == newHash);
        }

        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }

        // encrypting our save file string
        private string GetSHA256(string text)
        {
            // convert text into an array of bytes
            byte[] textToBytes = Encoding.UTF8.GetBytes(text);
            // instance to calculate hash values
            SHA256Managed mySHA256 = new SHA256Managed();
            byte[] hashValue = mySHA256.ComputeHash(textToBytes);

            return GetHexStringFromHash(hashValue);
        }

        public string GetHexStringFromHash(byte[] hash)
        {
            string hexString = String.Empty;

            // concatonate 2 digit bytes together
            foreach (byte b in hash)
            {
                hexString += b.ToString("x2");
            }
            return hexString;
        }
    }
}
