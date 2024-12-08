using UnityEngine;

public class HealingGlow : MonoBehaviour
{
    public Renderer objectRenderer; // Renderer for the healing object
    public Color glowColor = Color.green; // Color of the glow
    public float maxGlowIntensity = 2.0f; // Maximum intensity of the glow
    public float pulseSpeed = 2.0f; // Speed of the pulse effect
    public float activationDistance = 5.0f; // Distance at which the glow activates
    public Transform playerTransform; // Reference to the player's Transform
    public float transitionSpeed = 3.0f; // Speed of the glow transition
    private Material glowMaterial; // Reference to the glow material
    private float currentGlowIntensity = 0f; // Current intensity of the glow

    void Start()
    {
        // Get the second material (assuming it's the glow material)
        glowMaterial = objectRenderer.materials[1];
        glowMaterial.EnableKeyword("_EMISSION");
        glowMaterial.SetColor("_EmissionColor", glowColor * 0f); // No initial glow
    }

    void Update()
    {
        // Calculate the distance between the player and the healing object
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        // Determine the target glow intensity
        float targetGlowIntensity = distanceToPlayer <= activationDistance ? maxGlowIntensity : 0f;

        // Smoothly transition to the target glow intensity
        currentGlowIntensity = Mathf.Lerp(currentGlowIntensity, targetGlowIntensity, Time.deltaTime * transitionSpeed);

        // Apply the pulse effect if glowing
        float intensity = currentGlowIntensity > 0 ? currentGlowIntensity + Mathf.PingPong(Time.time * pulseSpeed, currentGlowIntensity) : 0f;

        // Update the emission color, maintaining the object's base texture
        glowMaterial.SetColor("_EmissionColor", glowColor * intensity);
    }

    // Code inspired by chatGPT and CoPilot AI
}
