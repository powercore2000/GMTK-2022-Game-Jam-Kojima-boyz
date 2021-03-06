using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;

namespace GameStateManager
{
    public class CombatRoomManager : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> playerPrefabs = new List <GameObject>();
        [SerializeField]
        List<string> prefabNames = new List<string>();
        Dictionary<string,GameObject> players = new Dictionary<string,GameObject>();

        [SerializeField]
        Transform playerSpawnPoint;

        [SerializeField] private SpriteRenderer background;
        [SerializeField] private Sprite[] backgroundSprites;

        public D6_Dice dice = new D6_Dice();
        // Start is called before the first frame update
        void Awake()
        {
            SetBackground();
            for (int a = 0; a < playerPrefabs.Count; a++) {

                players.Add(prefabNames[a], playerPrefabs[a]);
            }
            string className = "";

            try { className = GameStateManager.CurrentCharacterClass.ClassName(); }
            catch{

                Debug.Log("Defaulting!");
                className = "Warlock";
            }

            Instantiate(players[className], playerSpawnPoint.position, Quaternion.identity, playerSpawnPoint);
        }



        void SetBackground()
        {
            int result = Random.Range(0, backgroundSprites.Length);
            background.sprite = backgroundSprites[result];

        }
    }
}