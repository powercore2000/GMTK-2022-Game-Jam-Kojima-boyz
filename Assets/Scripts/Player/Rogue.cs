using GameStateManager;
using UnityEngine;

namespace PlayerSystems
{
    public class Rogue : CharacterClass
    {
        
    

        public void CriticleFailure()
        {
            throw new System.NotImplementedException();
        }

        public void Ability()
        {
            Debug.Log("Rogue!");
        }
        public override string ClassName()
        {
            return "Rogue";
        }


        public Rogue(CharacterClassStats stats) : base(stats)
        {
        }
    }
}