using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyDetector : MonoBehaviour
{
    private GameObject[] multipeEnemys;
    public Transform closestEnemy;
    public bool enemyContact;

    public Transform Player;

    public float closestDistance;
    public float currentDistance;

    public bool ClosestEnemyFound;

    public PlayerAttack playerAttack;

    public GameObject Sphere;

    public float Speed;

    private Coroutine LookCoroutine;

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(closestEnemy.position - Player.transform.position);

        float time = 0;
        while (time < 1)
        {
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, lookRotation, time);

            time += Time.deltaTime * Speed;
            yield return null;
        }
    }
    // public GameObject[] enemies;

    void Start()
    {
        //target = GameObject.FindWithTag("Eg").transform;

        closestEnemy = null;
        enemyContact = false;

    }

    void FixedUpdate()
    {
        if (enemyContact == true && playerAttack.FaceEnemy == true)
        {

            StartRotating();
            //Player.LookAt(closestEnemy);
            //transform.localRotation = Quaternion.identity;
            //transform.Rotate(closestEnemy);

            //transform.
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
        multipeEnemys = GameObject.FindGameObjectsWithTag("Test");
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
