using System;
using System.Collections.Generic;
using PlayerSystems;
using UnityEngine;
using UnityEngine.Events;

namespace GameStateManager
{
    public class ClassManager : MonoBehaviour
    {

        [SerializeField]
        List<ICharacterClass> characterClasses = new List<ICharacterClass>();

        [SerializeField]
        Transform classList;
        [SerializeField]
        GameObject classDisplayElement;

        UnityEvent OnClassSelected;
        CharacterClass TestClass = new CharacterClass("test");
        [SerializeField] private GameStateManager _gameStateManager;
        
        private void Start()
        {
            characterClasses.Add(new WarriorClass());
            ReloadList();
        }
        public void AssignPlayerClass(int classID) {
            switch (classID) {
                case 0:
                    {
                        _gameStateManager.AssignCharacterClass(TestClass);
                    }
                    break;
            }
            //Add this data to a game mamager to be used in other scenes
            OnClassSelected.Invoke();
        }
        public void Msg() {
            Debug.Log($"current class is {_gameStateManager.CurrentCharacterClass.ClassName}");
        }

        void ReloadList() {
            ClearList();
            LoadList();
        }

        void ClearList() {

            for (int a = 0; a < classList.childCount; a++) {
                Debug.Log("Destroying " + classList.GetChild(a).name);
                Destroy(classList.GetChild(a).gameObject);
            }
        
        }

        void LoadList() {

            foreach (var cc in characterClasses)
            {
                GameObject classElement = Instantiate(classDisplayElement, classList);
                classElement.GetComponent<CharacterClassElement>().SetValues(cc);
            }

        }

    }
    
    

    [System.Serializable]
    public class CharacterClass 
    {
        [field: SerializeField]
        public string ClassName { get; private set; }
        
      
        public Action OnFailure;
        public Action OnSucess;

        public CharacterClass(string nme) {

            ClassName = nme;
        }
        


    }
}