using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class BackToMainMenu : MonoBehaviour
{
    // Method to load the Main Menu scene
    public void OnReturnToMainMenu()
    {
        SceneManager.LoadScene("MainScreen"); // Assuming your Main Menu scene is named "MainMenu"
    }

    // Code inspired by chatGPT and CoPilot AI but I'm also just a girl
}