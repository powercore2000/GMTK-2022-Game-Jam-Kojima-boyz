using System.Collections;
using System.Collections.Generic;
using GameStateManager;
using UnityEngine;

public class SoundCleanUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAllSounds()
    {
        var listOfSounds = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < listOfSounds.Length; i++)
        {
            Destroy(listOfSounds[i].gameObject);
        }

        var soundManagerFromMainMenu = FindObjectsOfType<SoundManager>();
        for (int i = 0; i < soundManagerFromMainMenu.Length; i++)
        {
            var dontDestroy = soundManagerFromMainMenu[i].GetComponent<DontDestroyOnLoad>();
            if (dontDestroy)
            {
                Destroy(soundManagerFromMainMenu[i].gameObject);
                break;
            }
        }
    }
}
