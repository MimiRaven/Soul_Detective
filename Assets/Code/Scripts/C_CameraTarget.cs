using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CameraTarget : MonoBehaviour
{
    public Transform target;
    public float sightRange;
    public bool EnemyInRange;
    public LayerMask targetMask;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Eg").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        EnemyInRange = Physics.CheckSphere(transform.position, sightRange, targetMask);

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        //{
        //    Vector3 hitPosition = hit.point;
        //    turret.LookAt(hitPosition);
        //}
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
