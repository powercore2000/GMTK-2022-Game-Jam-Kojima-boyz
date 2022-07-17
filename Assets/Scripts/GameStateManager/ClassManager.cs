using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PlayerSystems;

namespace GameSystem
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

        private void Start()
        {
            characterClasses.Add(new WarriorClass());
            ReloadList();
        }
        public void AssignPlayerClass(int classID) {


            switch (classID) {

                case 0:
                    {

                        GameStateManager.AssignCharacterClass(TestClass);
                    }
                    break;
            
            }
            //Add this data to a game mamager to be used in other scenes
            OnClassSelected.Invoke();
        }

        public void Msg() {
            Debug.Log($"current class is {GameStateManager.CurrentCharacterClass.ClassName}");
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

            foreach (CharacterClass cc in characterClasses)
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