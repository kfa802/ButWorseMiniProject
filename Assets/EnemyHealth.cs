using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    private RagdollManager ragdollManager;
    private NavMeshAgent agent; // Reference to NavMeshAgent
    [HideInInspector] public bool isDead;

    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
        agent = GetComponent<NavMeshAgent>(); // Get NavMeshAgent component
    }
    
    public void TakeDamage(float damage)
    {
        if (isDead) return; // Prevent damage if already dead

        health -= damage;
        if (health <= 0) 
        {
            EnemyDeath();
        }
        else
        {
            Debug.Log("Hit");
        }
    }

    void EnemyDeath()
    {
        // Trigger ragdoll physics
        ragdollManager.TriggerRagdoll();
        
        // Disable NavMeshAgent to stop movement
        if (agent != null)
        {
            agent.isStopped = true; // Stops the agent from moving
            agent.enabled = false;  // Disables the NavMeshAgent completely
        }
        
        // Set isDead flag to true
        isDead = true;
        
        Debug.Log("Enemy Dead");
    }
}
