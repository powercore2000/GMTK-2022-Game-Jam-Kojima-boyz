using System.Collections;
using System.Collections.Generic;
using GameStateManager;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SoundManager _manager;
    void Start()
    {
        if (_manager!= null)
        _manager.PlayMenuMusic();
    }
    
}
