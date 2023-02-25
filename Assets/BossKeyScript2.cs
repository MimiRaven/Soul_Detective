using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKeyScript2 : MonoBehaviour
{

    public C_EmenyDeath C_EmenyDeath;
    public BossDeathManager BossDeathManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (C_EmenyDeath.EnemyCurrentHealth == 0)
        {
            BossDeathManager.Boss2Dead = true;
        }
    }
}
