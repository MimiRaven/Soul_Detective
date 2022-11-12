using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EmenyDeath : MonoBehaviour
{
    public C_XpScore c_XpScore;
    private bool isColliding = true;
    //public EnemyHealth enemyHealth;

    public int MaxHealth;
    public int PlayerCurrentHealth;

    //public GameObject healthBarUI;
    //public Slider slider;

    void Start()
    {
        PlayerCurrentHealth = MaxHealth;
        //slider.value = CalculateHealth();
    }

    void Update()
    {
        isColliding = false;
        //slider.value = CalculateHealth();
        EnemyDeath();

        //if (PlayerCurrentHealth <= MaxHealth)
        //{
        //    healthBarUI.SetActive(true);
        //}
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

       //if(col.collider.tag == "Player")
       //{
       //    C_PlayerHealth p = col.gameObject.GetComponent<C_PlayerHealth>();
       //    p.ChangeHealth(-1);
       //}

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
            //healthBarUI.SetActive(false);
            Destroy(gameObject);
            
        }

        //if(PlayerCurrentHealth == 0)
        //{
        //    healthBarUI.SetActive(false);
        //}

        //Destroy(gameObject);
        //enemyHealth.TakeDamage(1);

    }

    //float CalculateHealth()
    //{
    //    return PlayerCurrentHealth / MaxHealth;
    //}

}
