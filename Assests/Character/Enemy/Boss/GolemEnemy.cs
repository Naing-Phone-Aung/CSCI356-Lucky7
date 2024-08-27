using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GolemEnemy : MonoBehaviour
{
    public int MaxenemyHealth = 150;
    public int enemyHealth = 150;
    public Image HealthBar;
    float lerpSpeed;

    Combat playerInfo;

    public Animator golemAnimator;
    public NavMeshAgent golemAgent;
    public Transform playerPosition;
    float distanceToPlayer;
    public int distance;
    public int stopDistance;
    public int throwDistance;
    public int nearDistance;

    public int maxInt = 10;
    public int minInt = 15;

    // Stone info
    public Transform stoneSpawnPoint;
    public GameObject stonePrefab;
    GameObject stoneClone;

    private void HealthBarFiller()
    {
        // Calculate the health percentage and update the health bar fill
        float healthPercentage = (float)enemyHealth / MaxenemyHealth;
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, healthPercentage, lerpSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        golemAnimator = GetComponent<Animator>();
        golemAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth > MaxenemyHealth) enemyHealth = MaxenemyHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
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
            else if (enemyHealth <= 0)
            {
                // Golem is dead, handle death (if any logic is required)
                golemAnimator.SetInteger("State", 5);
                GameObject.Destroy(gameObject,7);

            }
            else if (distanceToPlayer <= nearDistance && enemyHealth <= 20 && enemyHealth >= 15)
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
            else if (distanceToPlayer < stopDistance && enemyHealth <= 150)
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

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    public void AttackToPlayer()
    {
        playerInfo = FindObjectOfType<Combat>();
        playerInfo.currentHealth -= Random.Range(maxInt, minInt);
    }

}