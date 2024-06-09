using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Controls")]
    public Joystick joystick;
    [Header("Info")]
    public TMP_Text pickupCounter;
    [Header("Interactables")]
    public Button useButton;
    public Interactable.InteractableType currentInteractableType;

    public GameObject deathPanel;
    public GameObject winPanel;
    public GameObject inGamePanel;

    [Header("MinigamePanel")] 
    public GameObject pcPanel;
    
    public void JumpButtonClicked()
    {
        GameManager.instance.PlayerMovementController.TriggerJumpAnim();
    }

    public void IncrementPickupCounter(int amount)
    {
        pickupCounter.text = (int.Parse(pickupCounter.text) + amount).ToString();
    }
    
    public void EnableUseButton(bool enable, Interactable.InteractableType type)
    {
        useButton.gameObject.SetActive(enable);
        currentInteractableType = type;
    }
    public void DeathPanel(bool enable)
    {
        deathPanel.SetActive(enable);
        inGamePanel.SetActive(!enable);
    }
    public void WinPanel(bool enable)
    {
        winPanel.SetActive(enable);
        inGamePanel.SetActive(!enable);
    }

    public void UseButtonClicked()
    {
        switch (currentInteractableType)
        {
            case Interactable.InteractableType.PC:
                pcPanel.gameObject.SetActive(true);
                pcPanel.transform.GetComponent<PC_Screen>().LaunchScreenUp();
                break;
            case Interactable.InteractableType.Circuit:
                break;
        }
    }
    
    
}