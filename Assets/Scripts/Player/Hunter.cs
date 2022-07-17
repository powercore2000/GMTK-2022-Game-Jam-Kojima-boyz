using GameStateManager;
using UnityEngine;

namespace PlayerSystems
{
    public class Hunter : CharacterClass
    {
        public override string ClassName()
        {
            return "Hunter";
        }

    

        public void CriticleFailure()
        {
            throw new System.NotImplementedException();
        }

        public void Ability()
        {
            Debug.Log("Hunter!");
        }

        public Hunter() : base()
        {
        }
    }
}