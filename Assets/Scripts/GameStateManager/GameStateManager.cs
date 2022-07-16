using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public static class GameStateManager 
    {
        public static CharacterClass CurrentCharacterClass { get; private set; }


        public static void AssignCharacterClass(CharacterClass cc) {


            CurrentCharacterClass = cc;

    }

    }
}