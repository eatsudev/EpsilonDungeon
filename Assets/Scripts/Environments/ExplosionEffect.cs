using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExplosionEffect : MonoBehaviour
{
    public Light2D explosionLight;  
    public float maxIntensity = 5f; 
    public float maxRadius = 3f;    
    public float explosionDuration = 0.5f;


    private void Start()
    {
        StartCoroutine(AnimateExplosion());
    }

    public IEnumerator AnimateExplosion()
    {
        float elapsedTime = 0f;

        while (elapsedTime < explosionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / explosionDuration;

            explosionLight.intensity = Mathf.Lerp(0f, maxIntensity, t);
            explosionLight.pointLightOuterRadius = Mathf.Lerp(0f, maxRadius, t);

            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < explosionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / explosionDuration;

            explosionLight.intensity = Mathf.Lerp(maxIntensity, 0f, t);
            explosionLight.pointLightOuterRadius = Mathf.Lerp(maxRadius, 0f, t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
