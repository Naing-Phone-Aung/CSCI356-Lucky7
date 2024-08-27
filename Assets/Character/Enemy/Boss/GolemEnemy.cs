using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GolemEnemy : MonoBehaviour
{
    //PlayerController myController;
    public Animator golemAnimator;
    public NavMeshAgent golemAgent;

    public int golemHealth;
    public Transform playerPosition;
    float distanceToPlayer;
    public int distance;
    public int stopDistance;
    public int throwDistance;
    public int nearDistance;

    // Stone info
    public Transform stoneSpawnPoint;
    public GameObject stonePrefab;
    GameObject stoneClone;

    // Start is called before the first frame update
    void Start()
    {
        golemAnimator = GetComponent<Animator>();
        golemAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        startFight();
    }

    public void startFight()
    {
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);

        if (distanceToPlayer <= distance)
        {
            if (distanceToPlayer >= stopDistance + 2)
            {
                golemAgent.isStopped = false;
                golemAnimator.SetInteger("State", 1);
                golemAgent.SetDestination(playerPosition.position);
            }
            else if (golemHealth <= 0)
            {
                // Golem is dead, handle death (if any logic is required)
                golemAnimator.SetInteger("State", 5);
            }
            else if (distanceToPlayer <= nearDistance && golemHealth <= 20 && golemHealth >= 15)
            {
                // Roar and spider appear
                golemAgent.isStopped = true;
                golemAnimator.SetInteger("State", 4);
                //spiderEnemy.enabled = true;
            }
            else if (distanceToPlayer <= nearDistance)
            {
                // Attack near (flexing muscle)
                golemAgent.isStopped = true;
                golemAnimator.SetInteger("State", 3);
            }
            else if (distanceToPlayer < stopDistance && golemHealth <= 40)
            {
                // Throw with stone distance
                golemAgent.isStopped = true;
                transform.LookAt(playerPosition.position);
                golemAnimator.SetInteger("State", 2);
            }
        }
    }

    public void ThrowStone()
    {
        stoneClone = Instantiate(stonePrefab, stoneSpawnPoint.position, stoneSpawnPoint.rotation);
        GameObject.Destroy(stoneClone, 5);
    }

    public void AttackToPlayer()
    {
        //myController.playerHealth--;
    }


}