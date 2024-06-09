using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserId;
    
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Die();
            Debug.Log("DEAD");
        }
    }
}
