using System;
using DG.Tweening;
using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    public int PlatformId;
    public bool hover;
    public int duration;

    public Vector3 Destination;

    [HideInInspector]
    public LevelManager levelManager;

    private Vector3 startPosition;

    private void Start()
    {
        if (hover)
        {
            StartCoroutine(HoverPlatform());
        }
    }

    private IEnumerator HoverPlatform()
    {
        while (true)
        {
            MovePlatform();
            yield return new WaitForSeconds(duration);
            ReversePlatform();
            yield return new WaitForSeconds(duration);
        }
    }

    public void MovePlatform()
    {
        startPosition = transform.position;
        transform.DOMove(new Vector3(transform.position.x,transform.position.y,transform.position.z) + Destination, duration).SetEase(Ease.Linear);
    }

    public void ReversePlatform()
    {
        transform.DOMove(startPosition, duration).SetEase(Ease.Linear);
        if(hover) return;
        foreach (var platformClass in levelManager.Platforms)
        {
            if (platformClass.platformList.PlatformId == PlatformId)
            {
                platformClass.hasMoved = false;
            }
        }
    }


    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.transform.parent = null;
            
        }
    }
}