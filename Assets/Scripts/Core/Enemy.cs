using System.Collections;
using System.Collections.Generic;
using DiceSystem;
using UnityEngine;

namespace Core
{
    public enum Type { Melee, Ranged }
    public class Enemy : Entity
    {
        public D6_Dice diceScript = new D6_Dice();
        private int rollResult;
        private Type _enemyType;

        void Start()
        {
            InitialRoll();
        }
        
        
        // Update is called once per frame
        void InitialRoll()
        {
            rollResult = diceScript.RollResult();
           // Debug.Log(rollResult);

            SpawnEnemiesDependingOnRollResults();
        }
        void SpawnEnemiesDependingOnRollResults()
        {
            if(rollResult >= 3)
            {
                _enemyType = Type.Ranged;
            //    Debug.Log("Spawn ranged");
            }
            else if(rollResult <= 3)
            {
                _enemyType = Type.Melee;
              //  Debug.Log("Spawn melees");
            }
        }
    }
}