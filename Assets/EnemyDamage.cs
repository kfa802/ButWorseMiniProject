using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10; // Damage dealt to the player
    public float attackCooldown = 1f; // Time between attacks

    private float lastAttackTime = 0f; // Keeps track of the last attack time

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the collided object is the player
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount); // Deal damage to the player
                }

                lastAttackTime = Time.time; // Update the last attack time
            }
        }
    }
}
