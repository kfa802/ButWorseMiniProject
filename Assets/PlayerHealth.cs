using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    public int currentHealth;  // Current health
    public Image[] heartImages;   // Array of heart image UI elements
    public GameObject gameOverScreen; // Game over screen

    private Vector3 lastCheckpointPosition; // Player's last checkpoint position

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        UpdateHeartSprites(); // Update heart sprites at the start

        // Hide Game Over screen at the start
        gameOverScreen.SetActive(false);

        // Set the checkpoint to the player's initial position at the start
        lastCheckpointPosition = transform.position;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds

        UpdateHeartSprites(); // Update the heart sprites

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds
        UpdateHeartSprites(); // Update the heart sprites
    }

    void Die()
    {
        gameOverScreen.SetActive(true); // Show Game Over screen
        StartCoroutine(ReloadSceneAfterDelay(0.8f)); // Reload scene after delay
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RespawnAtCheckpoint();
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition; // Update checkpoint
        Debug.Log("Checkpoint updated to: " + checkpointPosition);
    }

    void RespawnAtCheckpoint()
    {
        // Respawn player at the last checkpoint
        transform.position = lastCheckpointPosition;
        currentHealth = maxHealth; // Reset health
        UpdateHeartSprites(); // Update the heart sprites
        gameOverScreen.SetActive(false); // Hide Game Over screen
    }

    // Update Heart Sprites based on current health
    private void UpdateHeartSprites()
    {
        int fullHearts = currentHealth / (maxHealth / heartImages.Length); // Determine how many hearts are full
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < fullHearts)
            {
                heartImages[i].enabled = true; // Show the heart (full)
            }
            else
            {
                heartImages[i].enabled = false; // Hide the heart (empty)
            }
        }
    }
}
