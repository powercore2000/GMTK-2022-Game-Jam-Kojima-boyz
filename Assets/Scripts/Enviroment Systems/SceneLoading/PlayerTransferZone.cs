using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviromentSystems.SceneLoading
{
    public class PlayerTransferZone : MonoBehaviour
    {
        /*
         * This class is to be attached to an empty game object with a collider (usually sphere?)
         * The object has a scene variable to tell it what scene to load when the player arrives
         * When the player enters the collider, it triggers the load sequence for the next scene
         */
        [Header("Set In Inspector")]
        public int targetIdx;


        public void LoadTargetScene() {

            if (targetIdx >= 0) SceneManagerBehaviour.Instance.LoadNewLevelByIndex(targetIdx);

            else SceneManagerBehaviour.Instance.ReloadCurrentScene();
        }



    }
}