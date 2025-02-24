using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class LevelLoader : MonoBehaviour
{
    // Tag of the object that should trigger level loading
    public string targetTag = "Player"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag)) 
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
