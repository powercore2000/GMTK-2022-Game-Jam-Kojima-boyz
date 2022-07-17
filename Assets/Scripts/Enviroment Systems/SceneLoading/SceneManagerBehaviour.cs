using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using ScreenSpaceFxSystem;

namespace EnviromentSystems.SceneLoading
{
    [System.Serializable]
    public class SceneManagerBehaviour : MonoBehaviour
    {
        #region Static Fields

        public static Action OnSceneLoadCompletion;

        static Scene hubWorldScene;

        static bool isLoadingInProgress;
        public static bool IsLoadingInProgress => isLoadingInProgress;

        public static SceneManagerBehaviour Instance { get; private set; }
        #endregion


        #region Fields
        [SerializeField]
        UnityEvent OnSceneChangeInit = new UnityEvent();

        public bool disableTransitionFade;       

        int targetZoneIndex;
        #endregion


        #region MonoBehaviour

        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            if (isLoadingInProgress) {

                if (OnSceneLoadCompletion != null) OnSceneLoadCompletion.Invoke();
                isLoadingInProgress = false;
            }

            StartCoroutine(DelayedCanvasAdjustment());

        }
        
        IEnumerator DelayedCanvasAdjustment() {

            //Waits for the currently selected animation ScreenSpaceFxInstance is showing to finish before hiding the canvas
            yield return new WaitForSeconds(ScreenSpaceFxManager.ScreenSpaceFXInstance.FadeAnimationLength);
            ScreenSpaceFxManager.ScreenSpaceFXInstance.SetCanvasOrder(-1);
        }
        #endregion


        #region Sorting Methods
        public void ReloadCurrentScene() {

            Debug.Log("Reloading scene...");
            LoadNewLevelByIndex(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoadNewLevelByIndex(int index)
        {
            OnSceneChangeInit.Invoke();

            LoadNewZone(index);

        }

        public void LoadNewLevelByName(string targetSceneName)
        {
            int index = -1;
            OnSceneChangeInit.Invoke();

            //Debug.Log("Target scene name is " + targetSceneName);
            // Debug.Log("total scene count is " + SceneManager.sceneCountInBuildSettings);

            for (int a = 0; a < SceneManager.sceneCountInBuildSettings; a++)
            {
                //Debug.Log("scene name: " + SceneUtility.GetScenePathByBuildIndex(a));

                if (SceneUtility.GetScenePathByBuildIndex(a).Contains(targetSceneName + ".unity"))
                {
                    index = a;
                    break;
                }
            }
            LoadNewZone(index);

        }
        #endregion


        #region Scene Loading Methods
        public void LoadNewZone(int zoneID) {

            targetZoneIndex = zoneID;
            StartFadeTransition();
            

        }

        public void ReloadZone()
        {

            targetZoneIndex = SceneManager.GetActiveScene().buildIndex;
            StartFadeTransition();


        }

        public void StartFadeTransition()
        {
            if (!disableTransitionFade)
            {

                StartCoroutine(TransitionFade());
            }

            else
            {

                LoadScene();
                
            }
        }

        IEnumerator TransitionFade()
        {
            isLoadingInProgress = true;

            //Fade to black
            ScreenSpaceFxManager.ScreenSpaceFXInstance.SetCanvasOrder(100);
            ScreenSpaceFxManager.ScreenSpaceFXInstance.FadeToBlack();
            yield return new WaitForSeconds(ScreenSpaceFxManager.ScreenSpaceFXInstance.FadeAnimationLength + 0.5f);

            LoadScene();
        }


        void LoadScene() {


            SceneManager.LoadSceneAsync(targetZoneIndex, LoadSceneMode.Single);

        }

        void LoadSceneAdditive()
        {


            SceneManager.LoadSceneAsync(targetZoneIndex, LoadSceneMode.Additive);

        }

        void ReloadHubScene()
        {

            SceneManager.SetActiveScene(hubWorldScene);
            SceneManager.UnloadSceneAsync(-1);
           
        }
        #endregion

    }

}