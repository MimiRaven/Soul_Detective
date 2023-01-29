using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_enemyWeaponCollider : MonoBehaviour
{
    public GameObject RightHandCollider;
    public GameObject LeftHandCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightColliderON()
    {
        RightHandCollider.SetActive(true);
    }

    public void RightColliderOff()
    {
        RightHandCollider.SetActive(false);
        
    }

    public void LeftColliderON()
    {
        LeftHandCollider.SetActive(true);
    }

    public void LeftColliderOff() 
    {
        LeftHandCollider.SetActive(false);
    }   
}
