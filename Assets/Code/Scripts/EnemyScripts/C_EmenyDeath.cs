using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EmenyDeath : MonoBehaviour
{
    public C_XpScore c_XpScore;
    private bool isColliding = true;
    //public EnemyHealth enemyHealth;

    public int MaxHealth;
    public int PlayerCurrentHealth;

    void Start()
    {
        PlayerCurrentHealth = MaxHealth;
    }

    void Update()
    {
        isColliding = false;
        
        EnemyDeath();
    }

    void OnCollisionEnter(Collision col)
    {
        if (isColliding) return;
        isColliding = true;

        if (col.collider.tag == "weapon")
        {
            PlayerTakeDamage();
            //col.collider.GetComponent<EnemyHealth>().TakeDamage(1);
            // Destroy(gameObject);
            //script.TakeDamage(1);
            Debug.Log("Enemy Damaged");
        }

        if (col.collider.tag == "Active")
        {
            Debug.Log("Attack hit");
            PlayerTakeDamage();
        }

    }

    void PlayerTakeDamage()
    {
        PlayerCurrentHealth -= 1;
        
    }

    void EnemyDeath()
    {

        if(PlayerCurrentHealth <= 0)
        {
            c_XpScore.CurrentScore += 1;
            Destroy(gameObject);
            
        }

        //Destroy(gameObject);
        //enemyHealth.TakeDamage(1);

    }

}
