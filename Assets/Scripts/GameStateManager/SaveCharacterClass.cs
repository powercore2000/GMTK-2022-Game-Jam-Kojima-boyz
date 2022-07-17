using System;
using UnityEngine;

namespace GameStateManager
{
    [CreateAssetMenu(fileName = "CharacterClass", menuName = "CharacterClass/SaveCharacterClass", order = 0)]
    public class SaveCharacterClass : ScriptableObject
    {
        public string ClassName;
        public Action OnFailure;
        public Action OnSucess;
    }
}