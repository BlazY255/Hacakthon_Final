using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Managers")] 
    public static GameManager instance = null;
    public UIManager UIManager;
    public LevelManager levelManager;

    [Header("Player")] 
    public PlayerMovementController PlayerMovementController;

    [Header("Interaction")] 
    public bool canInteract;
    
    void Awake()
    {
        // QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void SetInteractionType(bool enable,Interactable.InteractableType type,int id,bool isLaserPc,bool isLastPc)
    {
        if (canInteract)
        {
            UIManager.pcPanel.transform.GetComponent<PC_Screen>().currentId = id;
            UIManager.pcPanel.transform.GetComponent<PC_Screen>().isLaserPc = isLaserPc;
            UIManager.pcPanel.transform.GetComponent<PC_Screen>().isLastPc = isLastPc;
            UIManager.EnableUseButton(enable, type);
        }
    }
    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Win()
    {
        UIManager.WinPanel(true);
    }

    public void Die()
    {
        UIManager.DeathPanel(true);
        Destroy(PlayerMovementController.gameObject); 
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
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