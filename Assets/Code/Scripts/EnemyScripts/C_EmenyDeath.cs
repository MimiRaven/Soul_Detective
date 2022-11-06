using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EmenyDeath : MonoBehaviour
{
    public C_XpScore c_XpScore;
    private bool isColliding = true;
    public EnemyHealth enemyHealth;

    void Update()
    {
        isColliding = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (isColliding) return;
        isColliding = true;

        if (col.collider.tag == "weapon")
        {
            EnemyDeath();
            //col.collider.GetComponent<EnemyHealth>().TakeDamage(1);
            // Destroy(gameObject);
            //script.TakeDamage(1);
            Debug.Log("Enemy Damaged");
        }

        if (col.collider.tag == "Active")
        {
            Debug.Log("Attack hit");
            EnemyDeath();
        }

    }


    void EnemyDeath()
    {
        
        c_XpScore.CurrentScore += 1;
        //Destroy(gameObject);
        enemyHealth.TakeDamage(1);

    }

}
