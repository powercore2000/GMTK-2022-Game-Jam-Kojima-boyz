using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;


namespace GameStateManager
{
    [System.Serializable]
    public class CharacterClass
    {
        
       protected  CharacterClassStats _characterClassStats;
       public CharacterClassStats CharacterStats => _characterClassStats;
        public CharacterClass()
        {
        }
        public CharacterClass( CharacterClassStats stats)
        {
            _characterClassStats = stats;
        }
        public virtual void Ability()
        {
        }

        public virtual string ClassName()
        {
            return default;
        }
        public Action OnFailure;
        public Action OnSucess;

        public override string ToString()
        {
            return "Health " + _characterClassStats.health +"\n" +
                   "DefaultDamage " + _characterClassStats.defaultDamage +" "+
                   "ExtraDamage " + _characterClassStats.extraDamage +"\n";
        }
    }
}