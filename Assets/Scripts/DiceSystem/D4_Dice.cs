using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem
{
    public class D4_Dice : ICustomDie
    {
        public int[] RollTableValues { get; private set; }

        public GameObject DicePrefab { get; private set; }

        public event EventHandler OnDieRoll;
        public event EventHandler OnDieRollVFX;

        public D4_Dice()
        {

            //Sets the roll table to be any value between 1 and 4
            RollTableValues = new int[] { 1, 2, 3, 4 };


        }

        //Returns random value from the dice
        public int RollResult()
        {
            //OnDieRoll.Invoke();
            //if (visualEffects) OnDieRollVFX.Invoke();
            return RollTableValues[UnityEngine.Random.Range(0, RollTableValues.Length)];
        }
    }
}