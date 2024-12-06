using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    public int currentHealth;  // Current health
    public Image[] heartImages;   // Array of heart image UI elements
    public GameObject gameOverScreen; // Game over screen
    public Button continueButton; // Continue button
    public Button mainMenuButton; // Main menu button

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        UpdateHeartSprites(); // Update heart sprites at the start

        // Hide Game Over screen at the start
        gameOverScreen.SetActive(false);

        // Set up button listeners
        continueButton.onClick.AddListener(OnContinueButtonClick);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
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
        Time.timeScale = 0; // Pause the game
        Cursor.visible = true; // Make the cursor visible
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }

    // On Continue button click: restart the current scene
    void OnContinueButtonClick()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // On Main Menu button click: load the main menu
    void OnMainMenuButtonClick()
    {
        Time.timeScale = 1; // Ensure time resumes before loading the main menu
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene (make sure the scene is named correctly)
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
