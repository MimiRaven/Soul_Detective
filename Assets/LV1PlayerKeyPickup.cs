using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1PlayerKeyPickup : MonoBehaviour
{
    public GameObject Door;

    public Level1SideQuestManager SideQuestManager;

   //void OnCollisionEnter(Collision collision)
   //{
   //    if (collision.gameObject.tag == "Key")
   //    {
   //       
   //
   //        Door.SetActive(false);
   //
   //
   //
   //
   //        Destroy(collision.gameObject);
   //
   //    }
   //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
          SideQuestManager.Quest5Complete = true;

            Door.SetActive(false);




            Destroy(other.gameObject);

        }
    }
}
