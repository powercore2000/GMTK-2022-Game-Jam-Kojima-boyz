using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem
{
    public class D12_Dice : ICustomDie
    {
        public int[] RollTableValues { get; private set; }

        public GameObject DicePrefab { get; private set; }

        public event EventHandler OnDieRoll;
        public event EventHandler OnDieRollVFX;

        public D12_Dice()
        {


            RollTableValues = Enumerable.Range(1, 12).ToArray();


        }

        public int RollResult()
        {
            //OnDieRoll.Invoke();
            //if (visualEffects) OnDieRollVFX.Invoke();
            return RollTableValues[UnityEngine.Random.Range(0, RollTableValues.Length)];
        }
    }
}