using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        private static int _mainMenuIndex = 1;

        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER Load Level Error: invalid scene name");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER Load Level Error: invalid scene index");
            }

        }

        public static void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        public static void LoadNextLevel()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;
            // wraps between total count and 0
            nextSceneIndex = nextSceneIndex % totalSceneCount;
            nextSceneIndex = Mathf.Clamp(nextSceneIndex, _mainMenuIndex, totalSceneCount);
            SceneManager.LoadScene(nextSceneIndex);
        }

        public static void LoadMainMenuLevel()
        {
            SceneManager.LoadScene(_mainMenuIndex);
        }
    }
}
