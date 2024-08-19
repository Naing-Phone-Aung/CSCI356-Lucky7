using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemEnemy : MonoBehaviour
{
    Combat playerInfo;

    public Animator golemAnimator;
    public NavMeshAgent golemAgent;

    public int golemHealth;
    public Transform playerPosition;
    float distanceToPlayer;
    public int distance;
    public int stopDistance;
    public int throwDistance;
    public int nearDistance;

    public Transform stoneSpawnPoint;
    public GameObject stonePrefab;
    GameObject stoneClone;

    void Start()
    {
        golemAnimator = GetComponent<Animator>();
        golemAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        StartFight();
    }

    public void StartFight()
    {
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);

        if (distanceToPlayer <= distance)
        {
            if (golemHealth <= 0)
            {
                golemAgent.isStopped = true;
                golemAnimator.SetInteger("State", 5); // Death state
            }
            else if (distanceToPlayer <= nearDistance)
            {
                golemAgent.isStopped = true;
                golemAnimator.SetInteger("State", 3); // Near attack state
            }
            else if (distanceToPlayer < stopDistance && golemHealth <= 40)
            {
                golemAgent.isStopped = true;
                transform.LookAt(playerPosition.position);
                golemAnimator.SetInteger("State", 2); // Throw stone state
            }
            else if (distanceToPlayer >= stopDistance + 2)
            {
                golemAgent.isStopped = false;
                golemAnimator.SetInteger("State", 1); // Move towards player
                golemAgent.SetDestination(playerPosition.position);
            }
            else
            {
                golemAgent.isStopped = true;
                golemAnimator.SetInteger("State", 0); // Idle state
            }
        }
        else
        {
            golemAgent.isStopped = true;
            golemAnimator.SetInteger("State", 0); // Idle state when out of range
        }
    }

    public void ThrowStone()
    {
        stoneClone = Instantiate(stonePrefab, stoneSpawnPoint.position, stoneSpawnPoint.rotation);
        Destroy(stoneClone, 5);
    }

    public void AttackToPlayer()
    {
        // Handle player attack logic
    }
}
