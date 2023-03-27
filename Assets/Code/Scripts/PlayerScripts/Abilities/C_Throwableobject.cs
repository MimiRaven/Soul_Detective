using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class C_Throwableobject : MonoBehaviour
{
    public bool WeaponActive;
   // public VisualEffect TeleVfxEffect;
    // AudioSource audioSource;
    //public AudioClip holdTelekinesis;


    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
       // TeleVfxEffect.Stop();
    }
    void Update()
    {
       if (WeaponActive == true)
       {
           //PlaySound(holdTelekinesis);
           gameObject.tag = "Active";
         //  TeleVfxEffect.Play();
       }
       
       if (WeaponActive == false)
       {
            gameObject.tag = "NotActive";
            //TeleVfxEffect.Stop();
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

     //if(collision.gameObject.tag == "Fence")
     //  {
     //      if(WeaponActive == true)
     //      {
     //          Destroy(gameObject);
     //          Destroy(collision.gameObject);
     //      }
     //  }

        if (collision.gameObject.tag == "Ground")
        {
            WeaponActive = false;
            //GameObject.tag = "NotsBox";

        }

    }

  //void PlaySound(AudioClip clip)
  //{
  //    audioSource.PlayOneShot(clip);
  //}
 
}
