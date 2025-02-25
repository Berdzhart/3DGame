using System.Collections;
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

    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }

    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
