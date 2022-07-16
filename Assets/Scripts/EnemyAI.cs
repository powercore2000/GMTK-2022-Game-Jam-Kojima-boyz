using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;

public enum range { Melee, Ranged }
public class EnemyAI : MonoBehaviour
{
    public D6_Dice diceScript = new D6_Dice();
    private int rollResult;
    private range enemyRange;

    void Start()
    {

        InitialRoll();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitialRoll()
    {
        rollResult = diceScript.RollResult();
        Debug.Log(rollResult);

        SpawnEnemiesDependingOnRollResults();
    }
    void SpawnEnemiesDependingOnRollResults()
    {
        if(rollResult >= 3)
        {
            enemyRange = range.Ranged;
            Debug.Log("Spawn ranged");
        }
        else if(rollResult <= 3)
        {
            enemyRange = range.Melee;
            Debug.Log("Spawn melees");
        }
    }
}
