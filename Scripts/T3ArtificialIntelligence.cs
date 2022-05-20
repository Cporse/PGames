using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3ArtificialIntelligence : MonoBehaviour
{
    public static T3ArtificialIntelligence Instance;

    [SerializeField] private float speed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
    }

    //Functions,

    //END LINE.
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class T3ArtificialIntelligence : MonoBehaviour
{
    public static T3ArtificialIntelligence Instance;
    public float health;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform character;
    [SerializeField] private LayerMask isCharacter, isGround;

    //DEVRiYE (PATROLING)
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private float walkPointRange;
    private bool walkPointSet;

    //SALDIRI (Attacking)
    [SerializeField] float timeBetweenAttacks;
    private bool alreadyAttacked;
    [SerializeField] private GameObject projectile;

    //STATE
    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        character = GameObject.Find("PlayerObj").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isCharacter);
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isCharacter);

        if (!playerInSightRange && !playerInAttackRange) functionPatroling();
        if (playerInSightRange && !playerInAttackRange) functionChasePlayer();
        if (playerInSightRange && playerInAttackRange) functionAttackPlayer();
    }

    //Functions,
    private void functionPatroling()
    {
        if (walkPointSet) functionSearchWalkPoint();

        if (walkPointSet) navMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }
    private void functionSearchWalkPoint()
    {
        //Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        //float randomY = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            walkPointSet = true;
        }
    }
    private void functionChasePlayer()
    {
        navMeshAgent.SetDestination(character.position);
    }
    private void functionAttackPlayer()
    {
        //Make sure enemy doesn't move,
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(character);

        if(!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(functionDestroyEnemy), .5f);
    }
    public void functionDestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    //END LINE.
}*/