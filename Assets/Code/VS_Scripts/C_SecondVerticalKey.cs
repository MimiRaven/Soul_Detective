using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SecondVerticalKey : MonoBehaviour
{
    //public GameObject Self;
    public GameObject Door;
    //public GameObject OtherEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log("Key Touched");
            //c_EnemyPossesed.Possesed = false;
            // Self.SetActive(false);
            Door.SetActive(false);
            //OtherEnemy.SetActive(true);
           
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }
}
