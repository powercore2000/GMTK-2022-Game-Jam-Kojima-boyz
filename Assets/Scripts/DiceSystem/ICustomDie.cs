using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem
{
    public interface ICustomDie
    {
        int[] RollTableValues { get; }
        GameObject DicePrefab { get; }

        event EventHandler OnDieRoll;
        event EventHandler OnDieRollVFX;
        public int RollResult(bool visualEffects);



    }
}