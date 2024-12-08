using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    public Button startGameButton; // Start Game button
    public CanvasGroup[] uiElements; // Array of CanvasGroups for multiple UI elements
    public float fadeDuration = 2f; // Duration for each UI element to fade in
    public float delayBetweenElements = 0.5f; // Delay between each element's fade-in


    void Start()
    {
        // Set up the Start Game button listener
        startGameButton.onClick.AddListener(OnStartGameButtonClick);

        // Set all UI elements to start invisible (alpha = 0)
        foreach (var element in uiElements)
        {
            element.alpha = 0f;
        }

        // Start the sequential fade-in effect
        StartCoroutine(SequentialFadeIn());
    }

    // Make this method public so it appears in the Inspector for the button
    public void OnStartGameButtonClick()
    {
        SceneManager.LoadScene("SampleScene"); // Load SampleScene (game scene)
    }

    // Coroutine to sequentially fade in UI elements with glitch
    private IEnumerator SequentialFadeIn()
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            // Start the fade-in effect for each UI element
            yield return StartCoroutine(FadeInUI(uiElements[i]));

            // Wait for the specified delay before starting the next fade-in
            yield return new WaitForSeconds(delayBetweenElements);
        }
    }

    // Coroutine to fade in a single UI element
    private IEnumerator FadeInUI(CanvasGroup uiElement)
    {
        float timeElapsed = 0f;

        // Gradually fade in the UI element
        while (timeElapsed < fadeDuration)
        {
            uiElement.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the UI element is fully visible at the end
        uiElement.alpha = 1f;

    }


    // Code inspired by chatGPT and CoPilot AI but I'm also just a girl

}
