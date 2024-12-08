using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public float chaseSpeed = 3.5f; // Default speed, adjustable in the Inspector

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed; // Set the initial speed
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
    
    // Code inspired by chatGPT and CoPilot AI but I'm also just a girl

}
