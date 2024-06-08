using DG.Tweening;
using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    public int PlatformId;
    public int descentAmount;
    public int duration;
    
    [HideInInspector]
    public LevelManager levelManager;

    private Vector3 startPosition;

    public void MovePlatform()
    {
        startPosition = transform.position;
        transform.DOMoveY(transform.position.y - descentAmount, duration).SetEase(Ease.Linear);
        StartCoroutine(ReverseAfterDelay(10f));
    }

    private IEnumerator ReverseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReversePlatform();
    }

    public void ReversePlatform()
    {
        transform.DOMoveY(startPosition.y, duration).SetEase(Ease.Linear);
        foreach (var platformClass in levelManager.Platforms)
        {
            if (platformClass.platformList.PlatformId == PlatformId)
            {
                platformClass.hasMoved = false;
            }
        }
        {
            
        }
    }
}