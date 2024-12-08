using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static int killCount = 0; // Static kill count

    // Method to increase the kill count
    public static void IncreaseKillCount()
    {
        killCount++;
    }

    // Method to reset the kill count
    public static void ResetKillCount()
    {
        killCount = 0; // Reset kill count to 0
    }
}
