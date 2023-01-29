using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_NavigationArrow : MonoBehaviour
{
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
        
        
            transform.LookAt(closestEnemy);
            //closestEnemy = getClosestEnemy();
        

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
        multipeEnemys = GameObject.FindGameObjectsWithTag("Objective");
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










    //public Transform target;
    //
    //
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    target = GameObject.FindWithTag("Objective").transform;
    //
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    transform.LookAt(target);
    //}
}
