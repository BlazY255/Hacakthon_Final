using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if next scene index is beyond the total scenes count
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Last scene reached, can't load next scene.");
            return;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void CloseGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
