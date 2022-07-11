using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace EnviromentSystems.LevelLoading
{
    [System.Serializable]
    public class SceneManagerBehaviour : MonoBehaviour
    {
        #region Static Fields

        public static Action OnLevelChangeEvents;

        static Scene hubWorldScene;

        #endregion


        #region Fields
        [SerializeField]
        UnityEvent OnNewLevelEvents = new UnityEvent();


        bool isLoadingInProgress;
        public bool IsLoadingInProgress => isLoadingInProgress;


        public bool disableTransitionFade;       

        int targetZoneIndex;
        #endregion


        #region MonoBehaviour
        void Start()
        {

            StartCoroutine(DelayedCanvasAdjustment());

        }
        
        IEnumerator DelayedCanvasAdjustment() {

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
            OnNewLevelEvents.Invoke();

            if (OnLevelChangeEvents != null)
            {

                OnLevelChangeEvents.Invoke();
            }

            LoadNewZone(index);
            // SceneManager.GetSceneByName("");

        }

        public void LoadNewLevelByName(string targetSceneName)
        {
            int index = -1;
            OnNewLevelEvents.Invoke();

            if (OnLevelChangeEvents != null)
            {

                OnLevelChangeEvents.Invoke();
            }

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
            //DebugPlayerValuesHolder.CanMove = false;
            isLoadingInProgress = true;
            //OverworldUIBehaviour.ToggleUI(false);
            //Fade to black
            ScreenSpaceFxManager.ScreenSpaceFXInstance.SetCanvasOrder(100);
            ScreenSpaceFxManager.ScreenSpaceFXInstance.FadeToBlack();
            yield return new WaitForSeconds(1.5f);
            //VisualEffectsManager.BlackOutFade(1f, true);


            //Hold black for 1 sec
            //yield return null;
            //yield return new WaitForSeconds(1);
            //ZoneManager.SwapLocations();



            LoadScene();
            //Unfade from black
            //VisualEffectsManager.BlackOutFade(1f, false);
            ScreenSpaceFxManager.ScreenSpaceFXInstance.FadeFromBlack();
            yield return new WaitForSeconds(ScreenSpaceFxManager.ScreenSpaceFXInstance.FadeAnimationLength);
            ScreenSpaceFxManager.ScreenSpaceFXInstance.SetCanvasOrder(1);
            //Wait until unfade has finished
            //yield return new WaitForSeconds(1);


            isLoadingInProgress = false;
            //DebugPlayerValuesHolder.CanMove = true;



        }


        void LoadScene() {


            SceneManager.LoadSceneAsync(targetZoneIndex, LoadSceneMode.Single);

        }
        void ReloadHubScene()
        {

            SceneManager.SetActiveScene(hubWorldScene);
            SceneManager.UnloadSceneAsync(-1);
           
        }
        #endregion

    }

}