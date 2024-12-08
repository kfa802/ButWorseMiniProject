using UnityEngine;

public class HealObject : MonoBehaviour
{
    public int healAmount = 25; // Amount of health the healing object gives
    public AudioClip healSound; // The sound to play when the herb is picked up
    public float volume = 1.0f; // Volume for the sound effect

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.CompareTag("Player")) // Check if the other collider has the "Player" tag
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Check if the player is not at full health
                if (playerHealth.currentHealth < playerHealth.maxHealth)
                {
                    playerHealth.Heal(healAmount); // Heal the player
                    Debug.Log("Healed player for: " + healAmount);

                    PlayHealSound(); // Play the heal sound effect

                    Destroy(gameObject); // Destroy the heal object after use
                }
                else
                {
                    Debug.Log("Player is at full health, cannot heal.");
                }
            }
            else
            {
                Debug.Log("PlayerHealth component not found on: " + other.gameObject.name);
            }
        }
    }

    private void PlayHealSound()
    {
        if (healSound != null)
        {
            // Play the sound at the object's position
            AudioSource.PlayClipAtPoint(healSound, transform.position, volume);
        }
        else
        {
            Debug.LogWarning("Heal sound is not assigned.");
        }
    }

    // Code inspired by chatGPT and CoPilot AI
}
