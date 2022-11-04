using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Throwableobject : MonoBehaviour
{
    public bool WeaponActive;

    

    void Update()
    {
       if (WeaponActive == true)
       {
           gameObject.tag = "Active";
       }
       
       if (WeaponActive == false)
       {
            gameObject.tag = "NotActive";
       }
    }


    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Enemy")
      {
         //if (WeaponActive == true)
         //{
         //    Destroy(gameObject);
         //    Destroy(collision.gameObject);
         //      Debug.Log("Attack hit");
         //      //WeaponActive = false;
         //      //GameObject.tag = "Box";
         //}
      
          
      }

        if (collision.gameObject.tag == "Ground")
        {
            WeaponActive = false;
            //GameObject.tag = "NotsBox";

        }

    }

 
}
