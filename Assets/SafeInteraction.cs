using UnityEngine;
using TMPro;

public class SafeInteraction : MonoBehaviour
{
    public int ammoReward = 10; // Amount of ammo to reward the player
    public KeyCode interactKey = KeyCode.E; // Key to open the safe
    //public PlayerAmmo playerAmmo; // Reference to the player's ammo system
    public TMP_Text interactionPrompt; // TextMeshPro text for interaction prompt

    private bool isPlayerNearby = false; // To track if the player is close

    void Start()
    {
        // Ensure the prompt is hidden at the start
        if (interactionPrompt != null)
            interactionPrompt.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionPrompt != null)
                interactionPrompt.gameObject.SetActive(true); // Show the prompt
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionPrompt != null)
                interactionPrompt.gameObject.SetActive(false); // Hide the prompt
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            OpenSafe();
        }
    }

    void OpenSafe()
    {
        Debug.Log("Safe opened! Ammo added: " + ammoReward);
        //playerAmmo.AddAmmo(ammoReward); // Call the player's method to add ammo
        if (interactionPrompt != null)
            interactionPrompt.gameObject.SetActive(false); // Hide the prompt
        Destroy(gameObject); // Optionally destroy the safe after opening
    }
}
