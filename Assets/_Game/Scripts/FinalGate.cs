using UnityEngine;

public class FinalGate : MonoBehaviour
{
    public Animator animator;
    public bool canEscape;
    
    public void OpenDoor()
    {
        animator.SetTrigger("Open");
        canEscape = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canEscape)
        {
            if (other.CompareTag("Player"))
            {
            
                GameManager.instance.Win();
            
            }
        }
        
    }
}
