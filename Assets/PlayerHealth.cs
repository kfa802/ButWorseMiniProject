using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    public int currentHealth;  // Current health
    public Image[] heartImages;   // Array of heart image UI elements
    public GameObject gameOverScreen; // Game over screen
    public Button continueButton; // Continue button
    public Button mainMenuButton; // Main menu button
    public Image bloodSplatterImage; // Blood splatter image
    public AudioSource damageSound; // Audio source for damage sound effect

    private float bloodSplatterDuration = 0.5f; // Duration the blood splatter stays visible
    private float bloodFadeDuration = 0.5f; // Duration for the fade-out effect

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartSprites();
        gameOverScreen.SetActive(false);

        if (bloodSplatterImage != null)
            bloodSplatterImage.color = new Color(1, 1, 1, 0); // Ensure blood splatter is invisible initially

        continueButton.onClick.AddListener(OnContinueButtonClick);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (damageSound != null)
        {
            damageSound.Play(); // Play the damage sound effect
        }

        ShowBloodSplatter(); // Show blood splatter on damage
        UpdateHeartSprites();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeartSprites();
    }

    void Die()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        KillManager.ResetKillCount();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnMainMenuButtonClick()
    {
        Time.timeScale = 1;
        KillManager.ResetKillCount();
        SceneManager.LoadScene("MainMenu");
    }

    private void UpdateHeartSprites()
    {
        int fullHearts = currentHealth / (maxHealth / heartImages.Length);
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = i < fullHearts;
        }
    }

    private void ShowBloodSplatter()
    {
        if (bloodSplatterImage != null)
        {
            bloodSplatterImage.color = new Color(1, 1, 1, 1); // Make the blood splatter visible
            StopAllCoroutines(); // Stop any ongoing fade-out coroutine
            StartCoroutine(FadeBloodSplatter()); // Start the fade-out effect
        }
    }

    private IEnumerator FadeBloodSplatter()
    {
        yield return new WaitForSeconds(bloodSplatterDuration); // Wait for the blood splatter duration

        float elapsed = 0f;
        Color initialColor = bloodSplatterImage.color;
        Color targetColor = new Color(1, 1, 1, 0); // Fully transparent

        while (elapsed < bloodFadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / bloodFadeDuration;
            bloodSplatterImage.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }

        bloodSplatterImage.color = targetColor; // Ensure it's fully transparent at the end
    }
}
