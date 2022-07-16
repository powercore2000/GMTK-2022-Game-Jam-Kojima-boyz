using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStates { Start, Playerturn, Enemyturn, Win, Lose}
public class TurnSystem : MonoBehaviour
{
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider enemyHealth;

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
    }
    public void Attack() // Player turn
    {
        if (states != BattleStates.Playerturn) return;


        DamageEnemy(25);
        //Enemy turn now
        if (HaveIDied()) return;
        StartCoroutine(EnemyTurn());
    }
    void DamageEnemy(float dmg)
    {
        enemyHealth.value -= dmg;
        Debug.Log("Enemy has been damaged");
        states = BattleStates.Enemyturn;
    }
    public void Heal()
    {
        if (states != BattleStates.Playerturn) return;
        StartCoroutine(HealThePlayer());
    }
    IEnumerator HealThePlayer()
    {
        yield return new WaitForSeconds(standardWaitTime);
        playerHealth.value += 10;
        Debug.Log("Healed the player");
        yield return new WaitForSeconds(1);

        states = BattleStates.Enemyturn;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator EnemyTurn()
    {
        if (states != BattleStates.Enemyturn) yield break;
        HaveIDied(); // Has enemy died?


        yield return new WaitForSeconds(standardWaitTime);
        DamagePlayer(30);
        Debug.Log("Player turn now");
        yield return new WaitForSeconds(standardWaitTime);

        HasPlayerDied();
        if (HasPlayerDied()) yield  break;
        states = BattleStates.Playerturn;
    }
    void DamagePlayer(int dmg)
    {
        playerHealth.value -= dmg;
    }
    bool HaveIDied()
    {
        if(enemyHealth.value <= 0)
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
        if(playerHealth.value <= 0)
        {
            Debug.Log("Player has lost the game");
            states = BattleStates.Lose;
            return true;
        }
        return false;
    }
}
