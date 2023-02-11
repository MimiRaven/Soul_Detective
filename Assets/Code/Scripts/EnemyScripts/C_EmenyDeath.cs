using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EmenyDeath : MonoBehaviour
{
    public Animator animator;
    public C_XpScore c_XpScore;
    public bool isColliding ;
    //public EnemyHealth enemyHealth;

    public float MaxHealth;
    public float EnemyCurrentHealth;

    public GameObject healthBarUI;
    public Slider slider;

    public float DeathTimer;
    public bool TimerOn;

    public bool EnemyIsDead;

    public GameObject Bot;
    public float range = 100f;
    public float KnockbackForce = 250;

    public AudioSource audioSource;
    //private AudioClip clip;

    void Start()
    {
        EnemyCurrentHealth = MaxHealth;
        slider.value = CalculateHealth();
        DeathTimer = 5;
        TimerOn = false;
        EnemyIsDead = false;
        //audioSource = GetComponent<AudioSource>(); 
        //audioSource.Stop();
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
        isColliding = false;
        Debug.Log("Collided");

        if (col.collider.tag == "weapon")
        {
            EnemyTakeDamage();
            //col.collider.GetComponent<EnemyHealth>().TakeDamage(1);
            // Destroy(gameObject);
            //script.TakeDamage(1);
            Debug.Log("Enemy Damaged");
            Knockback();
            isColliding = true;
            audioSource.Play();
        }


        if (col.collider.tag == "Active")
        {
            Debug.Log("Attack hit");
            Knockback();
            EnemyTakeDamage();
        }


        if (col.collider.tag == "BoostedWeapon")
        {
            BoostedWeaponDamage();
            Knockback();

            Debug.Log("Enemy Damaged");
        }



        if (col.collider.tag == "WeaponUpgraded1")
        {
            EnemyCurrentHealth -= 2;
            Knockback();

            Debug.Log("Enemy Damaged");
        }

        if (col.collider.tag == "WeaponUpgraded2")
        {
            EnemyCurrentHealth -= 3;
            Knockback();

            Debug.Log("Enemy Damaged");
        }

        if (col.collider.tag == "WeaponUpgraded3")
        {
            EnemyCurrentHealth -= 4;
            Knockback();

            Debug.Log("Enemy Damaged");
        }

        //if(col.collider.tag == "Player")
        //{
        //    C_PlayerHealth p = col.gameObject.GetComponent<C_PlayerHealth>();
        //    p.ChangeHealth(-1);
        //}

    }

   //void OnCollisionExit(Collision col)
   //{
   //    if (col.collider.tag == "weapon")
   //    {
   //        isColliding = false;
   //        Debug.Log("Collison Exit");
   //    }
   //
   //
   //}


    void EnemyTakeDamage()
    {
        EnemyCurrentHealth -= 1;

        //audioSource.PlayOneShot(clip);
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

    void Knockback()
    {
        Bot.transform.position += transform.forward * Time.deltaTime * KnockbackForce;
    }

}
