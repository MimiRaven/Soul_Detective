using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacementRecet : MonoBehaviour
{
    public C_EnemyPossesed C_EnemyPossesed;

    public Transform StartingPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(C_EnemyPossesed.Possesed == false)
        {
            transform.position = StartingPoint.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("PlatformArea"))
        {
            transform.position = StartingPoint.position;
        }
    }
}
