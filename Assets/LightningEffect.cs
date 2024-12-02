using UnityEngine;

public class LightningEffect : MonoBehaviour
{
    public Light lightningLight;  // Reference to the light used for lightning
    public float minLightningDuration = 0.1f;  // Minimum duration for the lightning flash
    public float maxLightningDuration = 0.5f;  // Maximum duration for the lightning flash
    public float minTimeBetweenFlashes = 1f;  // Minimum time between lightning flashes
    public float maxTimeBetweenFlashes = 5f;  // Maximum time between lightning flashes

    private float lightningTimer = 0f;  // Timer to track when to turn the light on
    private float flashDuration = 0f;  // Duration for the current flash
    private bool isFlashing = false;  // Whether the light is currently flashing

    void Start()
    {
        if (lightningLight == null)
        {
            lightningLight = GetComponent<Light>();  // Try to get the light component if not set
        }

        // Start with the light off
        lightningLight.enabled = false;
    }

    void Update()
    {
        // If the light is flashing, decrease the flash duration
        if (isFlashing)
        {
            flashDuration -= Time.deltaTime;
            if (flashDuration <= 0f)
            {
                // Turn the light off after the flash duration ends
                lightningLight.enabled = false;
                isFlashing = false;
            }
        }
        else
        {
            // If the light is not flashing, countdown the timer to the next potential flash
            lightningTimer -= Time.deltaTime;

            if (lightningTimer <= 0f)
            {
                // Randomly decide if the light should flash
                lightningTimer = Random.Range(minTimeBetweenFlashes, maxTimeBetweenFlashes);

                // Randomize the flash duration
                flashDuration = Random.Range(minLightningDuration, maxLightningDuration);

                // Turn the light on for the flash duration
                lightningLight.enabled = true;
                isFlashing = true;
            }
        }
    }
}
