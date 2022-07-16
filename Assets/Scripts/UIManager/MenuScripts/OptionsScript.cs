using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private Slider audioSlider;
    [SerializeField] private GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("SavedVolume", audioSlider.value);
    }
    public void BackToMain()
    {
        this.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
    // Load volume
}
