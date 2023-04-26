using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2BossHealth : MonoBehaviour
{
    public GameObject BossHealth;
    public C_EmenyDeath EnemyDeathScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDeathScript.EnemyCurrentHealth <= 0)
        {
            BossHealth.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LVBossBar2"))
        {
            BossHealth.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LVBossBar2"))
        {
            BossHealth.SetActive(false);
        }
    }
}
