using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;

public class HealObject : MonoBehaviour
{
    public int healAmount = 25; // Amount of health the healing object gives
    public TextMeshProUGUI healMessageText; // Reference to the TextMeshProUGUI component
    public float messageDisplayTime = 2f; // Time to display the heal message
    private bool messageIsDisplayed = false; // Flag to check if message is displayed

    void OnTriggerEnter(Collider other)
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

                    // Display the heal message
                    DisplayHealMessage("Healed " + healAmount + " life");

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

    void DisplayHealMessage(string message)
    {
        if (healMessageText != null && !messageIsDisplayed)
        {
            healMessageText.text = message; // Set the message text
            messageIsDisplayed = true;

            // Start the coroutine to hide the message after the specified time
            StartCoroutine(HideMessageAfterDelay());
        }
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime); // Wait for the specified time
        healMessageText.text = ""; // Clear the message
        messageIsDisplayed = false; // Allow the message to be shown again
    }
}
