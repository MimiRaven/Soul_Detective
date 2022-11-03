using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class C_EnemyRoam : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;

    //public float TimeLeft;
    //public bool TimerOn = false;

    private C_PlayerController playerController;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<C_PlayerController>();
        }
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (!playerInSightRange) Patroling();
        if (playerInSightRange) ChasePlayer();
        //Timmer();

      //if(walkPointSet = true)
      //{
      //    TimerOn = true;
      //}
    }

    void OnCollisionEnter(Collision col)
    {
        C_PlayerController player =  col.gameObject.GetComponent<C_PlayerController>();

        if(col.gameObject.name == "Cube")
        {
            Debug.Log("Enemy Toutched cube");
            Destroy(col.gameObject);
        }

         if (col.collider.tag == "weapon")
        {
            Destroy(gameObject);
        }

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
             agent.SetDestination(walkPoint);
            //TimerOn = true;
            //TimeLeft = 5f;

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 4f)
            walkPointSet = false;        
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
     private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
