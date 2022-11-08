using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CameraTarget : MonoBehaviour
{
    //public Transform target;
    //public float sightRange;
    //public bool EnemyInRange;
    //public LayerMask targetMask;
    // Start is called before the first frame update

    private GameObject[] multipeEnemys;
    public Transform closestEnemy;
    public bool enemyContact;

    public float closestDistance;
    public float currentDistance;

    void Start()
    {
        //target = GameObject.FindWithTag("Eg").transform;

        closestEnemy = null;
        enemyContact = false;

    }

    void FixedUpdate()
    {
        if (enemyContact == true)
        {
            transform.LookAt(closestEnemy);

        }

        closestEnemy = getClosestEnemy();
    }

    void Update()
    {
        //closestEnemy = getClosestEnemy();
        //transform.LookAt(closestEnemy);
        //if(enemyContact == true)
        //{
        //transform.LookAt(closestEnemy);
        //
        //}
        //closestEnemy = getClosestEnemy();

    }

    public Transform getClosestEnemy()
    {
        multipeEnemys = GameObject.FindGameObjectsWithTag("Eg");
         closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipeEnemys)
        {
            
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;

    }

   //void OnTriggerEnter(Collider collided)
   //{
   //    if(collided.tag("Eg"))
   //    {
   //        Debug.Log("Enemy in trigger");
   //        //closestEnemy = getClosestEnemy();
   //        //enemyContact = true;
   //        //transform.LookAt(closestEnemy);
   //    }
   //}

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Eg")
    //    {
    //        Debug.Log("Enemy in trigger");
    //        
    //        enemyContact = true;
    //
    //        //enemyContact = true;
    //
    //        //closestEnemy = getClosestEnemy();
    //
    //    }
    //}
    //
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Eg")
    //    {
    //        Debug.Log("Enemy in trigger");
    //        enemyContact = false;
    //        //closestEnemy = null;
    //
    //
    //    }
    //}

    //private void OntriggerExit(Collider collision)
    //{
    //    if (collision.isTrigger = !true && collision.CompareTag("Eg"))
    //    {
    //        enemyContact = false;
    //        Debug.Log("Enemy Not in trigger");
    //    }
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    //transform.LookAt(target);
    //    //
    //    //EnemyInRange = Physics.CheckSphere(transform.position, sightRange, targetMask);
    //
    //    //RaycastHit hit;
    //    //if (Physics.Raycast(transform.position, Vector3.forward, out hit))
    //    //{
    //    //    Vector3 hitPosition = hit.point;
    //    //    turret.LookAt(hitPosition);
    //    //}
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    //Gizmos.color = Color.red;
    //    //Gizmos.DrawWireSphere(transform.position, attackRange);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, sightRange);
    //}
}
