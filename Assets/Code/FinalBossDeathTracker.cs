using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDeathTracker : MonoBehaviour
{
    public Level3SideQuestManager questManager;
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
            questManager.FinalBossDead = true;

        }
    }


}
