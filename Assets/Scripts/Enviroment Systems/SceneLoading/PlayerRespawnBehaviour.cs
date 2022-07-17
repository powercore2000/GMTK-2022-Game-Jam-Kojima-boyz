using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviromentSystems.SceneLoading
{
    public class PlayerRespawnBehaviour : MonoBehaviour
    {
        [SerializeField]
        float delay;
        // Start is called before the first frame update
        public void Respawn()
        {
            StartCoroutine(ReloadDelay());
        }

        IEnumerator ReloadDelay() { 
        
        yield return new WaitForSeconds(delay);
            SceneManagerBehaviour.Instance.ReloadZone();


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}