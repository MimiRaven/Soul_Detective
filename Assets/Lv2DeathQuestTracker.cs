using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2DeathQuestTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public KillEnemysSideQuestTracker SideQuestTracker;
    public C_EmenyDeath EmenyDeath;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  SideQuestTracker.EnemysKilled += 1;

        if (EmenyDeath.EnemyIsDead == true)
        {

            SideQuestTracker.EnemysKilled += 1;
            
        }
    }
}
