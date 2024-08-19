using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class AntEnemy : MonoBehaviour
{
    public Transform playerPosition;
    private float distanceToPlayer;
    public int distance;
    public int stopDistance;

    private NavMeshAgent enemyAgent;
    public Animator enemyAnimator;

    Combat playerInfo;

    public int maxInt = 2;
    public int minInt = 5;

    public int enemyHealth;
    public bool isHitting;
    public bool isFollowing = false;

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetInteger("State", 3); // Idle state
    }

    private void Update()
    {
        if (isFollowing)
        {
            FollowToPlayer();
        }

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void FollowToPlayer()
    {
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);

        if (distanceToPlayer <= distance)
        {
            if (distanceToPlayer >= stopDistance)
            {
                enemyAgent.isStopped = false;
                enemyAgent.SetDestination(playerPosition.position);
                enemyAnimator.SetInteger("State", 1); // Walking state
            }
            else
            {
                enemyAgent.isStopped = true;
                enemyAnimator.SetInteger("State", 2); // Attack-ready state
            }
        }
        else if (distanceToPlayer > distance)
        {
            enemyAgent.isStopped = true;
            enemyAnimator.SetInteger("State", 3); // Idle state
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        isFollowing = true;
        isHitting = true;
        enemyAnimator.SetInteger("State", 4); // React to hit
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        enemyAnimator.SetInteger("State", 5); // Death state
        Destroy(gameObject, 3f); // Delay to play death animation
    }
    public void Attack()
    {
        playerInfo = FindObjectOfType<Combat>();
        playerInfo.currentHealth -= Random.Range(maxInt, minInt);
    }
}
