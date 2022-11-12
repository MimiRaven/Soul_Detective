using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    //Drive ds;

    public float wanderRadius = 1;
    public float wanderDistance = 5;
    public float wanderJitter = 5;
    public CamDetectTest camDetectTest;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
       // ds = target.GetComponent<Drive>();
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }


    Vector3 wanderTarget = Vector3.zero;
    void Wander()
    {
       //float wanderRadius = 1;
       //float wanderDistance = 5;
       //float wanderJitter = 5;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
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
    void Update()
    {
        if (camDetectTest.EnemyInRange == false)
        {
            Wander();
        }
        else
        {
            Seek(target.transform.position);
        }

        //Seek(target.transform.position);
        //Wander();
    }
}
