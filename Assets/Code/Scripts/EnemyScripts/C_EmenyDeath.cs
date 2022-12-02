using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EmenyDeath : MonoBehaviour
{
    public Animator animator;
    public C_XpScore c_XpScore;
    private bool isColliding = true;
    //public EnemyHealth enemyHealth;

    public float MaxHealth;
    public float EnemyCurrentHealth;

    public GameObject healthBarUI;
    public Slider slider;

    public float DeathTimer;
    public bool TimerOn;

    public bool EnemyIsDead;

    void Start()
    {
        EnemyCurrentHealth = MaxHealth;
        slider.value = CalculateHealth();
        DeathTimer = 5;
        TimerOn = false;
        EnemyIsDead = false;
    }
    

    void Update()
    {
        isColliding = false;
        slider.value = CalculateHealth();
        EnemyDeath();

        if (EnemyCurrentHealth == 0)
        {
            healthBarUI.SetActive(false);
        }

        //if (EnemyCurrentHealth < MaxHealth)
        //{
        //    healthBarUI.SetActive(true);
        //}
        if (TimerOn)
        {
            
            DeathTimer -= Time.deltaTime;
            if (DeathTimer <= 0)
            {
                c_XpScore.CurrentScore += 1;
                Destroy(gameObject);
            }
        }
       
    }

    void OnCollisionEnter(Collision col)
    {
        if (isColliding) return;
        isColliding = true;

        if (col.collider.tag == "weapon")
        {
            EnemyTakeDamage();
            //col.collider.GetComponent<EnemyHealth>().TakeDamage(1);
            // Destroy(gameObject);
            //script.TakeDamage(1);
            Debug.Log("Enemy Damaged");
        }


        if (col.collider.tag == "Active")
        {
            Debug.Log("Attack hit");
            EnemyTakeDamage();
        }


        if (col.collider.tag == "BoostedWeapon")
        {
            BoostedWeaponDamage();

            Debug.Log("Enemy Damaged");
        }

        //if(col.collider.tag == "Player")
        //{
        //    C_PlayerHealth p = col.gameObject.GetComponent<C_PlayerHealth>();
        //    p.ChangeHealth(-1);
        //}

    }

    void EnemyTakeDamage()
    {
        EnemyCurrentHealth -= 1;

    }

    void BoostedWeaponDamage()
    {
        EnemyCurrentHealth -= 3;
    }


    void EnemyDeath()
    {
        if (EnemyCurrentHealth <= 0)
        {
           
            healthBarUI.SetActive(false);
            animator.SetTrigger("Death");
            animator.SetBool("IsAttacking", false);
            TimerOn = true;
            EnemyIsDead = true;
            //Destroy(gameObject);

        }



        //Destroy(gameObject);
        //enemyHealth.TakeDamage(1);

    }

    float CalculateHealth()
    {
        return EnemyCurrentHealth / MaxHealth;
    }

}
