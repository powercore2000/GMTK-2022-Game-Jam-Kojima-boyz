using System;
using PlayerSystems;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameStateManager
{
    [System.Serializable]
    public class CharacterClassEvent : UnityEvent<CharacterClass>
    {
    }
    [RequireComponent(typeof(Button))]
    public class CharacterClassElement : MonoBehaviour
    {
        [SerializeField]
        TMP_Text text;
        [SerializeField]
        Image image;

      
        private void Awake()
        {
            
        }

        private void Start()
        {
            var gameManager = FindObjectOfType<GameStateManager>();
            var classManager = FindObjectOfType<ClassManager>();
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(gameManager.LoadNextLevel);
        }
        
        internal void SetValues(ICharacterClass cc)
        {
            text.text = cc.ClassName;
        }
    }
}