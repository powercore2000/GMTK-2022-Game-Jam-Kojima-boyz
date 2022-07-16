using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;
using MovementNamespace;


    public enum range { Melee, Ranged }

    [RequireComponent(typeof(Movement))]
    public class EnemyAI : Entity
    {

        public D6_Dice diceScript = new D6_Dice();
        private int rollResult;
        private range enemyRange;
        private TurnSystem.TurnSystemBehaviour turnSystem;

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
            if (rollResult >= 3)
            {
                enemyRange = range.Ranged;
                Debug.Log("Spawn ranged");
            }
            else if (rollResult <= 3)
            {
                enemyRange = range.Melee;
                Debug.Log("Spawn melees");
            }
        }

        public override void Move(Vector2 newPos)
        {
            if (turnSystem.canMove)
            {
                Debug.Log(turnSystem.canMove);
                Debug.Log("It's not your turn yet");
                return;
            }
            else
            {
                //_movement.Move(newPos);
                turnSystem.CanPlayerMove();
            }
        }
    }
