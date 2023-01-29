using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ReticalChange : MonoBehaviour
{
    public GameObject NormalRetical, AttackRetical;

    public C_RangeAttack c_RangeAttack;
    public C_Telekinesis c_Telekinesis;

    public bool RangeActive;
    public bool teleActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Tele();
        RangeAttack();


        //if(c_Telekinesis.ObjectGrabbed == true)
        //{
        //    AttackRetical.SetActive(true);
        //    NormalRetical.SetActive(false);
        //}
        //else
        //{
        //    NormalRetical.SetActive(true);
        //    AttackRetical.SetActive(false);
        //}

       //if (c_RangeAttack.ObjectGrabbed == true)
       //{
       //    AttackRetical.SetActive(true);
       //    NormalRetical.SetActive(false);
       //}
       //else
       //{
       //    NormalRetical.SetActive(true);
       //    AttackRetical.SetActive(false);
       //}
    }

    public void Tele()
    {
        if(RangeActive == false)
        {
              if (c_Telekinesis.ObjectGrabbed == true)
              {
                  RetAttack();
                teleActive = true;
              }
              else
              {
                  RetNormal();
                teleActive = false;
              }

        }
    }

  public void RangeAttack()
  {
    if(teleActive == false)
    {

              if (c_RangeAttack.ObjectGrabbed == true)
              {
                    RetAttack();
                    RangeActive = true;
              }
              else
              {
                    RetNormal();
                    RangeActive = false;
              }
    }
  }

    public void RetNormal()
    {
        NormalRetical.SetActive(true);
        AttackRetical.SetActive(false);
    }

    public void RetAttack()
    {
        AttackRetical.SetActive(true);
        NormalRetical.SetActive(false);
    }

}
