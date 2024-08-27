using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour
{
    public Transform playerPosition;
    float distanceToPlayer;
    public int distance;
    public int stopDistance;

    NavMeshAgent enemyAgent;
    public Animator enemyAnimator;

    public int enemyHealth;

    public bool isHitting;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowToPlayer();
        ReduceHealth();
    }

    void FollowToPlayer()
    {
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);

        if (distanceToPlayer <= distance)
        {
            if (distanceToPlayer >= stopDistance)
            {
                enemyAgent.isStopped = false;
                enemyAgent.SetDestination(playerPosition.position);
                enemyAnimator.SetInteger("State", 1);
            }
            else
            {
                enemyAgent.isStopped = true;
                enemyAnimator.SetInteger("State", 2);
                
            }
        }
        else if (distanceToPlayer > distance)
        {
            enemyAgent.isStopped = true;
            enemyAnimator.SetInteger("State", 3);
        }
    }

    public void ReduceHealth()
    {
        if (isHitting == true)
        {
            enemyAnimator.SetInteger("State", 4);
            isHitting = false;
        }
        else
        {
            FollowToPlayer();
        }
        if (enemyHealth <= 0)
        {
            enemyAnimator.SetInteger("State", 5);
            GameObject.Destroy(gameObject, 3);
        }
    }

}
