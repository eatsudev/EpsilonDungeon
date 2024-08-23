using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class LightBreathEffect : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D; 
    public float minIntensity = 0.5f; 
    public float maxIntensity = 1.5f; 
    public float breathSpeed = 1f; 

    private float initialIntensity;

    void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        }

        initialIntensity = light2D.intensity;
    }

    void Update()
    {
        // Breathing effect using a sine wave
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * breathSpeed) + 1f) / 2f);
    }
}

