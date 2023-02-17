using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CameraEnemyDetector : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public bool EnemyInRange;

    public C_EnemyDetector EnemyMoveto;

    void Start()
    {
        //StartCoroutine("FindTargetsWithDelay", .2f);
        //EnemyInRange = false;
    }

    void Update()
    {
        FindVisibleTargets();
        if (EnemyInRange == true)
        {
            EnemyMoveto.enemyContact = true;
        }
        else
        {
            EnemyMoveto.enemyContact = false;
        }

    }

    //IEnumerator FindTargetsWithDelay(float delay)
    //{
    //	while (true)
    //	{
    //		yield return new WaitForSeconds(delay);
    //		FindVisibleTargets();
    //	}
    //}

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        EnemyInRange = false;

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);


                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    EnemyInRange = true;
                }

            }
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
