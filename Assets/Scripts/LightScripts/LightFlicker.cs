using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light directionalLight;  // Reference to the directional light
    public float minIntensity = 0.5f;  // Minimum intensity of the light
    public float maxIntensity = 1.5f;  // Maximum intensity of the light
    public float flickerSpeed = 0.1f;  // Speed of the flicker effect

    private void Start()
    {
        if (directionalLight == null)
        {
            directionalLight = GetComponent<Light>();  // Try to get the light component if it's not set
        }
    }

    private void Update()
    {
        if (directionalLight != null)
        {
            // Randomly change the light intensity within the specified range
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, randomIntensity, flickerSpeed * Time.deltaTime);
        }
    }

    // Code inspired by chatGPT and CoPilot AI but I'm also just a girl
}
