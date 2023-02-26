using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1PlayerKeyPickup : MonoBehaviour
{
    public GameObject Door;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
           

            Door.SetActive(false);




            Destroy(collision.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
          

            Door.SetActive(false);




            Destroy(other.gameObject);

        }
    }
}
