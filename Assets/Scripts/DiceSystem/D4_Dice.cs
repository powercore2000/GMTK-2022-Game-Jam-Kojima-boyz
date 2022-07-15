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


            RollTableValues = new int[] { 1, 2, 3, 4 };


        }

        public int RollResult(bool visualEffects)
        {
            //OnDieRoll.Invoke();
            //if (visualEffects) OnDieRollVFX.Invoke();
            return RollTableValues[UnityEngine.Random.Range(0, RollTableValues.Length)];
        }
    }
}