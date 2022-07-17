using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class WarriorClass : ICharacterClass
    {
        public string ClassName => "Warrior";

        public void CriticleFailure()
        {
            throw new System.NotImplementedException();
        }

        public void Ability()
        {
            Debug.Log("Warrior!");
        }
    }
}