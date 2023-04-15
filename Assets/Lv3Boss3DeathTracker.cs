using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3Boss3DeathTracker : MonoBehaviour
{
    public LV3BossManager LV3BossManager;
    public C_EmenyDeath emenyDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (emenyDeath.EnemyCurrentHealth <= 1)
        {
            LV3BossManager.Boss3Dead = true;

        }
    }
}
