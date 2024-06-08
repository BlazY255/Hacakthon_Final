using System;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public int value;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constants.Player))
        {
            GameManager.instance.UIManager.IncrementPickupCounter(value);
            Destroy(gameObject);
        }
    }
    
}
