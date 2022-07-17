using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameStateManager
{
    public class GameStateManager: MonoBehaviour
    {
        public static CharacterClass CurrentCharacterClass { get; private set; }
        public static void AssignCharacterClass(CharacterClass cc) {
            CurrentCharacterClass = cc;
        }
        
        public static void LoadNextLevel()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            var nextSceneIndex = ++currentSceneIndex;
            var totalSceneCount = SceneManager.sceneCountInBuildSettings;
            LoadLevel(nextSceneIndex % totalSceneCount);
        }

        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && SceneManager.sceneCountInBuildSettings > levelIndex)
            {
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("invalid scene index");
            }
        }
        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }
        
    }
}