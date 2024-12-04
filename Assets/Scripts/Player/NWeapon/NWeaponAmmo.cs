using TMPro;
using UnityEngine;

public class NWeaponAmmo : MonoBehaviour
{
    public int clipSize; // Maximum bullets in the clip
    public int extraAmmo; // Bullets in reserve
    [HideInInspector] public int currentAmmo; // Bullets in the current clip

    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;

    public TMP_Text ammoDisplay; // Reference to the UI text for ammo display

    void Start()
    {
        currentAmmo = clipSize; // Initialize with full clip
        UpdateAmmoDisplay(); // Display initial ammo count
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        // Example: Shooting logic (replace or modify as needed)
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0) // Left mouse button
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        currentAmmo--;
        UpdateAmmoDisplay(); // Update UI after shooting
        // Add any shooting sound or effects here if needed
    }

    public void Reload()
    {
        if (extraAmmo > 0)
        {
            int ammoToReload = clipSize - currentAmmo;

            if (extraAmmo >= ammoToReload)
            {
                extraAmmo -= ammoToReload;
                currentAmmo += ammoToReload;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }

            // Optionally play reload sounds
            if (magOutSound != null) AudioSource.PlayClipAtPoint(magOutSound, transform.position);
            if (magInSound != null) AudioSource.PlayClipAtPoint(magInSound, transform.position);

            UpdateAmmoDisplay(); // Update UI after reloading
        }
    }

    public void AddAmmo(int amount)
    {
        extraAmmo += amount;
        UpdateAmmoDisplay(); // Update UI after gaining ammo
    }

    private void UpdateAmmoDisplay()
    {
        if (ammoDisplay != null)
        {
            ammoDisplay.text = $"{currentAmmo}/{extraAmmo}"; // Format: currentAmmo/extraAmmo
        }
    }
}
