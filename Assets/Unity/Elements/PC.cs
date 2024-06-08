using UnityEngine;

public class PC : MonoBehaviour
{
    public Interactable.InteractableType type;
    public int pcId;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetInteractionType(true, type,pcId);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetInteractionType(false, type,pcId);
        }
    }
}
