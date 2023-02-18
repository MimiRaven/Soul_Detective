using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    private GameObject[] multipeEnemys;
    public Transform closestEnemy;
    public bool enemyContact;

    public Transform Player;

    public float closestDistance;
    public float currentDistance;

    public bool ClosestEnemyFound;
    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        closestEnemy = getClosestEnemy();
    }

    public Transform getClosestEnemy()
    {
        multipeEnemys = GameObject.FindGameObjectsWithTag("Player");
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
}
