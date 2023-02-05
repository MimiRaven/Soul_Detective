using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public Animator animator;

    NavMeshAgent agent;
    public GameObject target;
    //Drive ds;

    public float wanderRadius = 1;
    public float wanderDistance = 5;
    public float wanderJitter = 5;
    public CamDetectTest camDetectTest;
    public C_EmenyDeath c_EmenyDeath;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;
    private Vector3 moveDirection;

    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        // ds = target.GetComponent<Drive>();

        agent.speed= speed;
        agent.SetDestination(RandomNavMeshLocation());
    }

    public Vector3 RandomNavMeshLocation() 
    {
        Vector3 finalposition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalposition= hit.position;
        }
        return finalposition;
    }

    void Seek(Vector3 location)
    {
        if(c_EmenyDeath.EnemyIsDead == false)
        {

        agent.SetDestination(location);
        }
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }


    Vector3 wanderTarget = Vector3.zero;
    void Wander()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLocation());
        }



        //float wanderRadius = 1;
        //float wanderDistance = 5;
        //float wanderJitter = 5;


        //////////

        //wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
        //                                0,
        //                                Random.Range(-1.0f, 1.0f) * wanderJitter);
        //wanderTarget.Normalize();
        //wanderTarget *= wanderRadius;
        //
        //Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        //Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);
        //
        //Seek(targetWorld);
    }

  //bool CanSeeTarget()
  //{
  //    RaycastHit raycastInfo;
  //    Vector3 rayToTarget = target.transform.position - this.transform.position;
  //    Debug.DrawRay(transform.position, rayToTarget, Color.green);
  //    if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
  //    {
  //        if (raycastInfo.transform.gameObject.tag == "Player")
  //            return true;
  //    }
  //    return false;
  //}


    // Update is called once per frame
    public void Update()
    {
        //if (knockBackCounter <= 0)
        //{
            if (camDetectTest.EnemyInRange == false)
            {
                Wander();
            }
            else
            {
                Seek(target.transform.position);
            }

            if (agent.speed >= 1)
            {
                animator.SetBool("IsWalking", true);
            }

       
        //}
        //else
        //{
        //    knockBackCounter -= Time.deltaTime;
        //}
        //Seek(target.transform.position);
        //Wander();
    }

    //public void Knockback(Vector3 direction)
    //{
    //    knockBackCounter = knockBackTime;
    //
    //    moveDirection = direction * knockBackForce;
    //}
}
