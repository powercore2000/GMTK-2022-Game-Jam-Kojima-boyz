using System;
using System.Collections;
using System.Threading.Tasks;
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

        IEnumerator StartLoadingRoutine(int nextLevelIndex)
        {
            yield return new WaitForSeconds(2f);
            LoadLevel(nextLevelIndex);
        }
        public  void LoadNextLevel()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            var nextSceneIndex = ++currentSceneIndex;
            var totalSceneCount = SceneManager.sceneCountInBuildSettings;
            StartCoroutine(StartLoadingRoutine(nextSceneIndex % totalSceneCount));
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


        public void Wait(float time)
        {
            StartCoroutine(WaitTimeRoutine( time));
        }

        private static IEnumerator WaitTimeRoutine(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}