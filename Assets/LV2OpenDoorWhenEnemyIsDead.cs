using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2OpenDoorWhenEnemyIsDead : MonoBehaviour
{
    public GameObject Door;
    public C_EmenyDeath emenyDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (emenyDeath.EnemyCurrentHealth == 0)
        {
            Door.SetActive(false);
        }
     
    }
}
