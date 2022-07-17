using System;
using UnityEngine;

namespace GameStateManager
{
    [CreateAssetMenu(fileName = "CharacterStats", menuName = "CharacterClass/Stats", order = 0)]
    
    public class CharacterClassStats : ScriptableObject
    {
        public int health;
        [Header("Attack damage")]
        [Header("Die : 2-5")]
        public int defaultDamage;
        [Header("Die : 6")]
        public int extraDamage;
    }
}