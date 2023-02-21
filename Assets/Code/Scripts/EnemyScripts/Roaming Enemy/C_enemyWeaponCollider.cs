using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_enemyWeaponCollider : MonoBehaviour
{
    public GameObject RightHandCollider;
    public GameObject LeftHandCollider;

    public GameObject PosRightHandCollider;
    public GameObject PosLeftHandCollider;

    public C_EnemyPossesed c_EnemyPossesed;

    public bool FaceEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTurnToEnemy()
    {
        FaceEnemy = true;
    }

    public void EndTurnToEnemy()
    {
        FaceEnemy = false;
    }

    public void RightColliderON()
    {
        if(c_EnemyPossesed.Possesed == true)
        {
          PosRightHandCollider.SetActive(true);

        }
            
        if(c_EnemyPossesed.Possesed == false)
        {
            RightHandCollider.SetActive(true);
        }
    }

    public void RightColliderOff()
    {
       //if(c_EnemyPossesed.Possesed == true)
       //{
       //
       //}
       //else
       //{
       //
       //}
          PosRightHandCollider.SetActive(false);
          RightHandCollider.SetActive(false);
        
    }

    public void LeftColliderON()
    {
        if (c_EnemyPossesed.Possesed == true)
        {
            PosLeftHandCollider.SetActive(true);

        }
        if (c_EnemyPossesed.Possesed == false)
        {
            LeftHandCollider.SetActive(true);

        }
    }

    public void LeftColliderOff() 
    {
       //if (c_EnemyPossesed.Possesed == true)
       //{
       //
       //}
       //else
       //{
       //
       //}
          PosLeftHandCollider.SetActive(false);
            LeftHandCollider.SetActive(false);
    }   
}
