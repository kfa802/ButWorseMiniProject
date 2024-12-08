using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;  // The spotlight representing the flashlight
    public KeyCode toggleKey = KeyCode.F;  // Key to toggle the flashlight
    public bool isFlickering = false;  // If the flashlight is flickering
    public float flickerIntervalMin = 0.05f;  // Min interval between flickers
    public float flickerIntervalMax = 0.2f;  // Max interval between flickers
    public float flickerIntensityMin = 0.3f;  // Min intensity during flicker
    public float flickerIntensityMax = 1.0f;  // Max intensity during flicker

    private float nextFlickerTime = 0f;  // When the next flicker should occur
    private float currentFlickerTime = 0f;  // Timer for current flicker

    void Start()
    {
        if (flashlight == null)
        {
            flashlight = GetComponentInChildren<Light>();  // Automatically find the flashlight if not assigned
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            flashlight.enabled = !flashlight.enabled;  // Toggle flashlight
            if (flashlight.enabled)
            {
                StartFlicker();  // Start flickering when flashlight is turned on
            }
            else
            {
                StopFlicker();  // Stop flickering when flashlight is turned off
            }
        }

        if (isFlickering && flashlight.enabled)
        {
            // Handle flicker logic here
            currentFlickerTime += Time.deltaTime;

            if (currentFlickerTime >= nextFlickerTime)
            {
                // Randomize the next flicker time
                nextFlickerTime = Random.Range(flickerIntervalMin, flickerIntervalMax);

                // Randomly set the light intensity to simulate flicker
                flashlight.intensity = Random.Range(flickerIntensityMin, flickerIntensityMax);

                currentFlickerTime = 0f;  // Reset the flicker timer
            }
        }
    }

    private void StartFlicker()
    {
        isFlickering = true;
        currentFlickerTime = 0f;  // Reset flicker time
    }

    private void StopFlicker()
    {
        isFlickering = false;
        flashlight.intensity = 1.0f;  // Set the flashlight to its normal intensity
    }

    // Code inspired by chatGPT and CoPilot AI but I'm also just a girl

}
