using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class C_EnemyRoam : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //public float TimeLeft;
    //public bool TimerOn = false;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }


    private void Update()
    {
        Patroling();
        //Timmer();

      //if(walkPointSet = true)
      //{
      //    TimerOn = true;
      //}

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Cube")
        {
            Debug.Log("Enemy Toutched cube");
            Destroy(col.gameObject);
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
}
