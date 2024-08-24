using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; 
    public float shakeIntensity = 1f; 
    public float shakeDuration = 0.5f; 

    private CinemachineBasicMultiChannelPerlin perlin;
    private float shakeElapsedTime = 0f;

    private void Start()
    {
        if (virtualCamera != null)
        {
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (perlin != null)
            {
                perlin.m_AmplitudeGain = 0f; 
            }
        }
    }

    private void Update()
    {
        if (shakeElapsedTime > 0)
        {
            shakeElapsedTime -= Time.deltaTime;
            if (perlin != null)
            {
                perlin.m_AmplitudeGain = Mathf.Lerp(shakeIntensity, 0f, 1 - (shakeElapsedTime / shakeDuration));
            }

            if (shakeElapsedTime <= 0 && perlin != null)
            {
                perlin.m_AmplitudeGain = 0f; 
            }
        }
    }

    public void ShakeCamera(float intensity, float duration)
    {
        if (perlin != null)
        {
            shakeIntensity = intensity;
            shakeDuration = duration;
            shakeElapsedTime = shakeDuration;
            perlin.m_AmplitudeGain = intensity; 
        }
    }
}
