using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private GameStateManager.GameStateManager _gameStateManager;

    private Scene savedScene;
    void Start()
    {
        SavedVolume();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        _gameStateManager.LoadNextLevel();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("savedScene"));
    }
    public void LoadNextScene()
    {
        _gameStateManager.LoadNextLevel();
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
        SaveVolume();
        Application.Quit();
    }
    public void SaveVolume()
    {
        AudioListener.volume = audioSlider.value;
        audioSlider.value = AudioListener.volume;
        PlayerPrefs.SetFloat("SavedVolume", AudioListener.volume);

        Debug.Log("Saved volume");
    }
    public void SavedVolume()
    {
        audioSlider.value = PlayerPrefs.GetFloat("SavedVolume");

        AudioListener.volume = audioSlider.value;
        audioSlider.value = AudioListener.volume;
    }
}
