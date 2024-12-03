using UnityEngine;

public class NWeaponRecoil : MonoBehaviour
{
    [SerializeField] Transform recoilFollowPos; // Object that visually follows the recoil.
    [SerializeField] float kickBackAmount = -1f; // How much the recoil pushes back.
    [SerializeField] float kickBackSpeed = 10f; // Speed of the backward recoil motion.
    [SerializeField] float returnSpeed = 20f;   // Speed of returning to the initial position.

    private float currentRecoilPosition = 0f; // Current offset due to recoil.
    private float targetRecoilPosition = 0f;  // Target offset for recoil.
    
    void Update()
    {
        // Smoothly interpolate current recoil position to the target recoil position.
        currentRecoilPosition = Mathf.Lerp(currentRecoilPosition, targetRecoilPosition, kickBackSpeed * Time.deltaTime);

        // Gradually return the recoil position to 0 when recoil ends.
        targetRecoilPosition = Mathf.Lerp(targetRecoilPosition, 0f, returnSpeed * Time.deltaTime);

        // Apply the recoil offset to the recoilFollowPos.
        recoilFollowPos.localPosition = new Vector3(0, 0, currentRecoilPosition);
    }

    // Trigger recoil by adding the kickback amount.
    public void TriggerRecoil()
    {
        targetRecoilPosition += kickBackAmount;
    }
}
