using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem
{
    //Generic Interface for any Dice we want to impliment
    public interface ICustomDie
    {
        //total table of values the die can return when rolled
        int[] RollTableValues { get; }
        //Prefab Gameobject to spawn when dice is rolled
        GameObject DicePrefab { get; }

        //Events to subscribe to when the dice is rolled
        event EventHandler OnDieRoll;
        event EventHandler OnDieRollVFX;

        //Return a nradom vlaue from the RollTable Values when rolled
        public int RollResult();



    }
}