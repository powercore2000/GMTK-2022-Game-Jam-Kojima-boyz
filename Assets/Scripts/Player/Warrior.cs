using System.Collections;
using System.Collections.Generic;
using GameStateManager;
using UnityEngine;

namespace PlayerSystems
{
    public class Warrior : CharacterClass
    {
        

        public void CriticleFailure()
        {
            throw new System.NotImplementedException();
        }

        public override string ClassName()
        {
            return "Warlock";
        }

        
        public void Ability()
        {
            Debug.Log("Warrior!");
        }
        
        public Warrior() : base()
        {
        }
    }
}