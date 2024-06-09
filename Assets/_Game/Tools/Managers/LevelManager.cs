using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<PlatformClass> Platforms;
    public List<Laser> lasers;

    public FinalGate finalGate;

    [System.Serializable]
    public class PlatformClass
    {
        public Platform platformList;
        public bool hasMoved;
    }

    private void Start()
    {
        foreach (var platformClass in Platforms)
        {
            platformClass.platformList.levelManager = this;
        }
    }


    public void SetPlatformActive(int platformId,bool active,bool isLaserPC,bool isLastPC)
    {
        
        foreach (var laser in lasers)
        {
            if(!isLaserPC) break;
            if (laser.laserId == platformId)
            {
                laser.gameObject.SetActive(!laser.gameObject.activeSelf);
            }
        }

        if (platformId == 5 && isLastPC && !isLaserPC)
        {
            Debug.Log("Final Gate Opened");
            finalGate.OpenDoor();
            
        }
        
        foreach (var platformClass in Platforms)
        {
            var platform = platformClass.platformList;
            if (platform.PlatformId == platformId)
            {
                if (active && !platformClass.hasMoved)
                {
                    platform.MovePlatform();
                    platformClass.hasMoved = true;
                }
                else if (!active)
                {
                    platform.ReversePlatform();
                    platformClass.hasMoved = false;
                }
            }
        }
    }
}