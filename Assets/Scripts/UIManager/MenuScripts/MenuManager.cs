using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Slider audioSlider;


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
       GameStateManager.GameStateManager.LoadNextLevel(); // Start scene
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("savedScene"));
    }
    public void LoadNextScene()
    {
        GameStateManager.GameStateManager.LoadNextLevel();
    }
    public void SaveScene()
    {
        PlayerPrefs.SetInt("savedScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game saved");
    }
    public void Options()
    {
        optionsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("SavedVolume", audioSlider.value);
    }
}
