using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management

public class MainMenuScript : MonoBehaviour
{
    public Button startGameButton; // Start Game button

    void Start()
    {
        // Set up the Start Game button listener
        startGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    // Make this method public so it appears in the Inspector for the button
    public void OnStartGameButtonClick()
    {
        SceneManager.LoadScene("SampleScene"); // Load SampleScene (game scene)
    }
}
