using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyDistanceDetect : MonoBehaviour
{
    public string tagToDetect = "Eg";
    public GameObject[] allEnemies;
    public GameObject closestEnemy;
    // Start is called before the first frame update
    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag(tagToDetect);
    }




    // Update is called once per frame
    void Update()
    {
        closestEnemy = ClosestEnemy();
        print(closestEnemy.name);
    }


    GameObject ClosestEnemy()
    {

        GameObject closestHere = gameObject;
        float leastDistance = Mathf.Infinity;

        foreach (var enemy in allEnemies)
        {

            float distanceHere = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceHere < leastDistance)
            {
                leastDistance = distanceHere;
                closestHere = enemy;

            }

        }
        return closestHere;
    }
}
