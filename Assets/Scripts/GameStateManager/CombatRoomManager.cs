using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameStateManager
{
    public class CombatRoomManager : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> playersToSpawn = new List<GameObject>();

        [SerializeField]
        //[SerializeField]

        // Start is called before the first frame update
        void Start()
        {
            string className = "";

            switch (className) {

                case "Warrior":
                    {

                        //playersToSpawn[0];
                    }
                    break;

                case "Hunter":
                    {


                    }
                    break;

                case "Theif":
                    {


                    }
                    break;


            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}