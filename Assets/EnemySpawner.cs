using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public Transform[] spawnPoints; // Array of spawn point transforms
    public float spawnDelay = 2f; // Delay between spawns
    public Transform playerTarget; // The player or target for the enemies to chase

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay); // Calls SpawnEnemy at regular intervals
    }

    void SpawnEnemy()
    {
        // Randomly select a spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        // Instantiate the enemy at the chosen spawn point
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Get the EnemyAI script attached to the spawned enemy
        EnemyAI enemyAI = newEnemy.GetComponent<EnemyAI>();

        // Set the target (player or other object) for the spawned enemy
        if (enemyAI != null)
        {
            enemyAI.target = playerTarget; // Set the target reference dynamically
        }
    }
}
