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

    public bool ClosestEnemyFound;

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
            //closestEnemy = getClosestEnemy();
        }

       //if (ClosestEnemyFound == false)
       //{
       //    closestEnemy = null;
       //}
        closestEnemy = getClosestEnemy();
        //else { closestEnemy = null; }

        //closestEnemy = getClosestEnemy();

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
            ClosestEnemyFound = true;
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;

            }
        }
        return trans;

    }

    //Transform GetClosestEnemy(Transform[] enemies)
    //{
    //    enemies = GameObject.FindGameObjectsWithTag("Eg");
    //    Transform tMin = null;
    //    float minDist = Mathf.Infinity;
    //    Vector3 currentPos = transform.position;
    //    foreach (Transform t in enemies)
    //    {
    //        float dist = Vector3.Distance(t.position, currentPos);
    //        if (dist < minDist)
    //        {
    //            tMin = t;
    //            minDist = dist;
    //        }
    //    }
    //    return tMin;
}
