using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public enum classes { Warrior, Warlock, Rogue, Hunter }
    public classes playerRace; 
    // Add to this line with the actual classes on the playerscript
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerClass();
            SavePlayerHealth();
            SaveRoom();
            SavePlayerHealth();
            Debug.Log(GetClassValue());
        }
        
    }
    void SavePlayerClass()
    {
        PlayerPrefs.SetInt("CharacterClass", CheckAndGiveClassValue());
    }
    int GetClassValue()
    {
        return PlayerPrefs.GetInt("CharacterClass");
    }
    int CheckAndGiveClassValue()
    {
        if (playerRace == classes.Warrior) return 0;
        if (playerRace == classes.Warlock) return 1;
        if (playerRace == classes.Rogue) return 2;
        return 3;
    }
    int CheckPlayerHealth() // Needs reference to health
    {
        return 0; // <<--- player.Health;
    }
    void SavePlayerHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", CheckPlayerHealth());
    }

    int CheckActualRoom() // Needs reference room value
    {
        return 0; //<<room value
    }
    void SaveRoom()
    {
        PlayerPrefs.SetInt("RoomStatus", CheckActualRoom());
    }

    int CheckScore() // Needs Reference to score
    {
        return 0; //<<score
    }
    void SaveScore()
    {
        PlayerPrefs.SetInt("SavedScore", CheckScore());
    }
}

