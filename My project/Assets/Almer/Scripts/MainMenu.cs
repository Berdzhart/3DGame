using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsScreen;

    void Awake()
    {
        
    }

    void Start()
    {
        settingsScreen.gameObject.SetActive(false);
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1;
    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene("Starting Screen");
        Time.timeScale = 1;
    }

    public void ToSettings()
    {
        settingsScreen.gameObject.SetActive(true);
    }

    public void QuitSettings()
    {
        settingsScreen.gameObject.SetActive(false);
    }
}
