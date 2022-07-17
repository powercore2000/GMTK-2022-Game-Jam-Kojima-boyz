using System;

namespace GameStateManager
{
    [System.Serializable]
    public class CharacterClass
    {
        public CharacterClass()
        {
        }

        public virtual void Ability()
        {
        }

        public virtual string ClassName()
        {
            return "NULL";
        }
        public Action OnFailure;
        public Action OnSucess;
        
    }
}