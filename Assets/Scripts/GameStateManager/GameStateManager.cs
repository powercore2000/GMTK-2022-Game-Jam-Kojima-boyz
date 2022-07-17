using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameStateManager
{
    public class GameStateManager: MonoBehaviour
    {

        [SerializeField]  SaveCharacterClass _currentCharacterClass;
        
        public  SaveCharacterClass CurrentCharacterClass => _currentCharacterClass;
        public  void AssignCharacterClass(CharacterClass cc) {
            _currentCharacterClass.ClassName = cc.ClassName;
            _currentCharacterClass.OnFailure = cc.OnFailure;
            _currentCharacterClass.OnSucess = cc.OnSucess;
           
        }

        private void Update()
        {
            Debug.Log(CurrentCharacterClass);
        }

        IEnumerator StartLoadingRoutine(int nextLevelIndex)
        {
            yield return new WaitForSeconds(1f);
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

        public  void LoadLevel(int levelIndex)
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
        public  void ReloadLevel()
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