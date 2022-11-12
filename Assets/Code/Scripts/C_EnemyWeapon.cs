using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyWeapon : MonoBehaviour
{
    public bool isColliding = true;

    public float Invicablitylength;

    private float InvicablityCounter;

    void Update()
    {
        isColliding = false;

        if (InvicablityCounter > 0)
        {
            InvicablityCounter -= Time.deltaTime;
        }
    }

   //void OnCollisionEnter(Collision col)
   //{
   //    if(InvicablityCounter <= 0)
   //    {
   //         if (isColliding) return;
   //         isColliding = true;
   //
   //         if (col.collider.tag == "Player")
   //         {
   //             Debug.Log("Enemy wep hit");
   //             C_PlayerHealth p = col.gameObject.GetComponent<C_PlayerHealth>();
   //             p.ChangeHealth(-1);
   //
   //             InvicablityCounter = Invicablitylength;
   //         }
   //
   //    }
   //
   //}

}
