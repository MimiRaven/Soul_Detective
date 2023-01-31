using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float knockbackStrength;

    
    //public float 

    
  //void OnCollisionEnter(Collision collision)
  //{
  //    Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
  //
  //    if (rb != null)
  //    {
  //        Vector3 direction = collision.transform.position - transform.position;
  //        direction.y = 0;
  //
  //        rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
  //    }
  //    //Destroy(gameObject);
  //}

    void OnCollisionEnter(Collision collision)
    {
        //Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (collision.gameObject.tag == "Enemy")
        {
            //Vector3 direction = collision.transform.position - transform.position;
            //direction.y = 0;
            //
            //rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);

            Debug.Log("WeponScriptHit");
        }
        //Destroy(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   //void OnCollisionEnter(Collision col)
   //{
   //    Debug.Log("Collision!");
   //    if (col.gameObject.name == "Enemy")
   //    {
   //        col.gameObject.GetComponent<Rigidbody>().AddForce(0, forceApplied, 0);
   //    }
   //}
}
