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