using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class CharacterClassElement : MonoBehaviour
    {
        [SerializeField]
        TMP_Text text;
        [SerializeField]
        Image image;

        internal void SetValues(CharacterClass cc)
        {
            text.text = cc.ClassName;
        }
    }
}