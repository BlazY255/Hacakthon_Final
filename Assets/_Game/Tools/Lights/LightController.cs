using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [Header("Lights To Control")]
    public List<GameObject> lights;

    [Header("Setters")] 
    public float blinkDelay;
    public float blinkDelayBetweenBlinks;
    public int blinkCount;
    
    
    void Start()
    {
        StartCoroutine(BlinkLights());
    }
    IEnumerator BlinkLights()
    {
        yield return new WaitForSeconds(blinkDelay);
        while (true)
        {
            for (int i = 0; i < blinkCount; i++)
            {
                foreach (var light in lights)
                {
                    for (int j = 0; j < blinkCount; j++)
                    {
                        light.SetActive(!light.activeSelf);
                        yield return new WaitForSeconds(blinkDelayBetweenBlinks);
                    }

                }

            }

            yield return new WaitForSeconds(blinkDelay);
        }
    }
}
