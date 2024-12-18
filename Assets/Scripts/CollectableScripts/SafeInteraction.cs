using UnityEngine;
using TMPro;

public class SafeInteraction : MonoBehaviour
{
    public int ammoReward = 10; // Amount of ammo to reward the player
    public KeyCode interactKey = KeyCode.E; // Key to open the safe
    public TMP_Text interactionPrompt; // TextMeshPro text for interaction prompt

    private bool isPlayerNearby = false; // To track if the player is close
    private NWeaponAmmo playerAmmo; // Reference to the player's ammo system

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

            // Search for NWeaponAmmo in the children of the Player GameObject
            playerAmmo = other.GetComponentInChildren<NWeaponAmmo>();
            if (playerAmmo != null)
            {
                Debug.Log("Player weapon ammo system found!");
            }
            else
            {
                Debug.LogWarning("Player weapon does not have NWeaponAmmo component!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionPrompt != null)
                interactionPrompt.gameObject.SetActive(false); // Hide the prompt

            playerAmmo = null; // Clear the reference when the player leaves
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

        // Add ammo to the player's extra ammo if the reference exists
        if (playerAmmo != null)
        {
            playerAmmo.extraAmmo += ammoReward;
        }

        if (interactionPrompt != null)
            interactionPrompt.gameObject.SetActive(false); // Hide the prompt

        Destroy(gameObject); // Optionally destroy the safe after opening
    }

    // Code inspired by chatGPT and CoPilot AI but I'm also just a girl
}
