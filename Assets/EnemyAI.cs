using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState { Patrol, Chase, Attack }
    public EnemyState currentState;

    public Transform[] patrolPoints; // Set these in the Inspector
    private int currentPatrolIndex;

    public Transform target; // Player or object to chase
    public float detectionRange = 10f;
    public float attackRange = 2f;

    public float patrolSpeed = 1f; // Speed for patrolling
    public float chaseSpeed = 4f; // Speed for chasing

    public float attackCooldown = 1.5f; // Time between attacks
    private float lastAttackTime;

    private NavMeshAgent agent;
    private EnemyHealth enemyHealth; // Reference to the EnemyHealth script

    [Header("Enemy Damage Settings")]
    [Tooltip("The amount of damage the enemy deals to the player when attacking.")]
    public int damage = 1; // Damage dealt by the enemy when attacking

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>(); // Get the EnemyHealth script
        currentState = EnemyState.Patrol;
        currentPatrolIndex = 0;
        MoveToNextPatrolPoint();
    }

    void Update()
    {
        if (enemyHealth.isDead) // If the enemy is dead, stop any further actions
        {
            return;
        }

        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    void Patrol()
    {
        agent.speed = Mathf.Lerp(agent.speed, patrolSpeed, Time.deltaTime * 2f);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPatrolPoint();
        }

        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            currentState = EnemyState.Chase;
        }
    }

    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void Chase()
    {
        agent.speed = Mathf.Lerp(agent.speed, chaseSpeed, Time.deltaTime * 2f);

        agent.SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            currentState = EnemyState.Attack;
            agent.isStopped = true;
        }
        else if (Vector3.Distance(transform.position, target.position) > detectionRange)
        {
            currentState = EnemyState.Patrol;
            agent.isStopped = false;
            MoveToNextPatrolPoint();
        }
    }

    void Attack()
    {
        if (enemyHealth.isDead) // Prevent attack if the enemy is dead
        {
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);

        if (Time.time > lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Use the configurable damage value
            }

            lastAttackTime = Time.time;
        }

        if (Vector3.Distance(transform.position, target.position) > attackRange)
        {
            currentState = EnemyState.Chase;
            agent.isStopped = false;
        }
    }
}
