using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyKnockBack : MonoBehaviour
{

    public Rigidbody rb;
    Vector3 targetPos;

    public float PushForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
    

        if (col.collider.tag == "weapon")
        {
            rb.AddForce(transform.forward * -PushForce, ForceMode.Impulse);
        }
    }
}
