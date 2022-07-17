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

        private void Start()
        {
            characterClasses.Add(new Warrior());
            characterClasses.Add(new Rogue());
            characterClasses.Add(new Warlock());
            characterClasses.Add(new Hunter());
        }

        public void AssignPlayerClass(int classID)
        {
            GameStateManager.AssignCharacterClass(characterClasses[classID]);
        }


    }
}