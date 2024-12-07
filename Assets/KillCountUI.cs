using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class KillCountUI : MonoBehaviour
{
    public Text killCountText;  // Reference to the Text UI element

    void Update()
    {
        // Update the UI text with the current kill count
        killCountText.text = "Kills: " + KillManager.killCount;
    }
}
