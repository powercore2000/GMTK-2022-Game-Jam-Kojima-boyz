using System.Collections.Generic;
using PlayerSystems;
using UnityEngine;
using UnityEngine.Events;

namespace GameStateManager
{
    public class ClassManager : MonoBehaviour
    {

        [SerializeField] List<CharacterClass> characterClasses = new List<CharacterClass>();

        [SerializeField] Transform classList;
        [SerializeField] GameObject classDisplayElement;

        UnityEvent OnClassSelected;
        [SerializeField] private GameStateManager _gameStateManager;
        [SerializeField] private CharacterClassStats _warriorClassStats;
        [SerializeField] private CharacterClassStats _rogueClassStats;
        
        [SerializeField] private CharacterClassStats _warloclClassStats;
        [SerializeField] private CharacterClassStats _hunterClassStats;
        private void Start()
        {
            characterClasses.Add(new Warrior(_warriorClassStats));
            characterClasses.Add(new Rogue(_rogueClassStats));
            characterClasses.Add(new Warlock(_warloclClassStats));
            characterClasses.Add(new Hunter(_hunterClassStats));
        }

        public void AssignPlayerClass(int classID)
        {
            GameStateManager.AssignCharacterClass(characterClasses[classID]);
        }


    }
}