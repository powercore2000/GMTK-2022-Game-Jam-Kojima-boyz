using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;


    public Scene savedScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // Start scene
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("savedScene"));
    }
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
    public void SaveScene()
    {
        PlayerPrefs.SetInt("savedScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game saved");
    }
    public void Options()
    {
        optionsMenu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }

}
