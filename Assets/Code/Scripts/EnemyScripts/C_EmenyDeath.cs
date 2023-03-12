using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class C_EmenyDeath : MonoBehaviour, IDataPersistence
{
    public Animator animator;
    public C_XpScore c_XpScore;
    public bool isColliding;
    //public EnemyHealth enemyHealth;

    public float MaxHealth;
    public float EnemyCurrentHealth;

    public GameObject healthBarUI;
    public Slider slider;

    public float DeathTimer;
    public bool TimerOn;

    public bool EnemyIsDead;

    // public GameObject Bot;
    public float range = 100f;
    public float KnockbackForce = 250;

    public AudioSource audioSource;

    public C_EnemyPossesed c_EnemyPossesed;
    public C_PlayerController c_PlayerController;
    private AudioClip clip;

    public VisualEffect HitEffect;

    [SerializeField] private string id;



    // public bool EnemyIsDead;
    public GameObject Self;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.EnemysKilled.TryGetValue(id, out EnemyIsDead);
        if (EnemyIsDead)
        {
            Self.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.EnemysKilled.ContainsKey(id))
        {
            data.EnemysKilled.Remove(id);
        }
        data.EnemysKilled.Add(id, EnemyIsDead);
    }


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

        if (EnemyIsDead)
        {
            TimerOn = false;
            Self.SetActive(false);
            // DeathTimer= 5;
            //c_XpScore.CurrentScore += 1;
        }

        if (DeathTimer == 1)
        {
            c_XpScore.CurrentScore += 1;
        }

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
                EnemyIsDead = true;
                //TimerOn = false;


                //Destroy(gameObject);
            }
        }
        else
        {
            DeathTimer = 5;
        }

    }

    public void GainXP()
    {
        c_XpScore.CurrentScore += 1;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (isColliding) return;
        isColliding = true;

        if (collision.gameObject.tag == "EnemyWeapon" && c_EnemyPossesed.Possesed == true)
        {
            EnemyTakeDamage();
            audioSource.Play();
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (isColliding) return;
        isColliding = false;
        Debug.Log("Collided");



        if (c_EnemyPossesed.Possesed == false)
        {


            if (col.collider.tag == "weapon")
            {
                EnemyTakeDamage();
                //col.collider.GetComponent<EnemyHealth>().TakeDamage(1);
                // Destroy(gameObject);
                //script.TakeDamage(1);
                Debug.Log("Enemy Damaged");
                Knockback();
                isColliding = true;

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
                audioSource.Play();
                Knockback();

                Debug.Log("Enemy Damaged");
            }



            if (col.collider.tag == "WeaponUpgraded1")
            {
                EnemyCurrentHealth -= 2;
                audioSource.Play();
                Knockback();

                Debug.Log("Enemy Damaged");
            }

            if (col.collider.tag == "WeaponUpgraded2")
            {
                EnemyCurrentHealth -= 3;
                audioSource.Play();
                Knockback();

                Debug.Log("Enemy Damaged");
            }

            if (col.collider.tag == "WeaponUpgraded3")
            {
                EnemyCurrentHealth -= 4;
                audioSource.Play();
                Knockback();

                Debug.Log("Enemy Damaged");
            }
        }

        //if (c_EnemyPossesed.Possesed == true)
        //{
        //   if (col.collider.tag == "EnemyWeapon")
        //   {
        //        Debug.Log("Possesed EnemyHit");
        //        EnemyCurrentHealth -= 1;
        //        Debug.Log("Enemy Damaged");
        //  
        //   }
        //
        //}

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
        audioSource.Play();
        HitEffect.Play();
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

            //c_XpScore.CurrentScore += (1);

            if (c_EnemyPossesed.Possesed == true)
            {
                c_EnemyPossesed.Possesed = false;
                c_PlayerController.Possesed = true;
            }

            //c_PlayerController.Possesed = true;
            // c_EnemyPossesed.Possesed = false;
            healthBarUI.SetActive(false);
            animator.SetTrigger("Death");
            animator.SetBool("IsAttacking", false);
            TimerOn = true;
            //audioSource.Play();
            //EnemyIsDead = true;
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
        // Bot.transform.position += transform.forward * Time.deltaTime * KnockbackForce;
    }

}
