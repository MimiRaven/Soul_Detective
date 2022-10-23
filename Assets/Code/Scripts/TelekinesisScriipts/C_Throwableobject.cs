using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Throwableobject : MonoBehaviour
{
    public bool WeaponActive;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (WeaponActive == true)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }

            
        }

        if (collision.gameObject.tag == "Ground")
        {
            WeaponActive = false;

        }

    }

 
}
