using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




namespace TurnSystem
{
    public enum BattleStates { Start, Playerturn, Enemyturn, Win, Lose }
    public class TurnSystemBehaviour : MonoBehaviour
    {
        [SerializeField] private Slider playerHealth;
        [SerializeField] private Slider enemyHealth;


        public bool canMove;
        private int standardWaitTime = 2; // The standard wait time for coroutines with no specific wait time.
        public BattleStates states;
        // Start is called before the first frame update
        void Start()
        {
            states = BattleStates.Start;

            StartCoroutine(SetGameUp());
        }

        // Update is called once per frame
        void Update()
        {

        }
        IEnumerator SetGameUp()
        {
            Debug.Log("Setting up game");
            // Animation/Telegraph of enemy

            yield return new WaitForSeconds(standardWaitTime);
            states = BattleStates.Playerturn; // It's now the player turn
            yield return new WaitForSeconds(standardWaitTime);
            PlayerTurn();
        }
        public void PlayerTurn() // Player turn
        {
            if (states != BattleStates.Playerturn) return;

        }
        public void Attack(float dmg)
        {
            if (states != BattleStates.Playerturn) return;
            enemyHealth.value -= dmg;
            Debug.Log("Enemy has been damaged");


            if (HasEnemyDied()) return;
            states = BattleStates.Enemyturn;
            StartCoroutine(EnemyTurn());
        }
        public void Heal()
        {
            if (states != BattleStates.Playerturn) return;
            StartCoroutine(HealThePlayer());
            states = BattleStates.Enemyturn;
        }
        public void CanPlayerMove()
        {
            if (states != BattleStates.Playerturn) return;
            if (states == BattleStates.Playerturn)
            {
                canMove = true;
            }

        }
        public void HasMoved()
        {
            states = BattleStates.Enemyturn;
            CanPlayerMove();
            StartCoroutine(EnemyTurn());
        }



        IEnumerator HealThePlayer()
        {
            yield return new WaitForSeconds(standardWaitTime);
            playerHealth.value += 10;
            Debug.Log("Healed the player");
            yield return new WaitForSeconds(1);

            StartCoroutine(EnemyTurn());
        }
        public void StartEnemyCoroutine()
        {
            StartCoroutine(EnemyTurn());
        }
        public IEnumerator EnemyTurn()
        {
            if (states != BattleStates.Enemyturn) yield break;
            HasEnemyDied(); // Has enemy died?


            yield return new WaitForSeconds(standardWaitTime);
            DamagePlayer(30);
            Debug.Log("Player turn now");
            yield return new WaitForSeconds(standardWaitTime);

            HasPlayerDied();
            if (HasPlayerDied()) yield break;
            states = BattleStates.Playerturn;
        }
        
        void DamagePlayer(int dmg)
        {
            playerHealth.value -= dmg;
        }
        bool HasEnemyDied()
        {
            if (enemyHealth.value <= 0)
            {
                //Debug.Log("Player has won");
                states = BattleStates.Win;
                return true;
            }
            // Debug.Log("Enemy still alive");
            return false;
        }
        bool HasPlayerDied()
        {
            if (playerHealth.value <= 0)
            {
                Debug.Log("Player has lost the game");
                states = BattleStates.Lose;
                return true;
            }
            return false;
        }
    }
}

