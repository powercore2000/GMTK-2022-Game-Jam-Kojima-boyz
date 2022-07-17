using GameStateManager;
using UnityEngine;

namespace PlayerSystems
{
    public class Warlock : CharacterClass
    {
        public override string ClassName()
        {
            return "Warlock";
        }


        public void CriticleFailure()
        {
            throw new System.NotImplementedException();
        }

        public void Ability()
        {
            Debug.Log("Warlock!");
        }

        public Warlock(CharacterClassStats stats) : base(stats)
        {
        }
    }
}