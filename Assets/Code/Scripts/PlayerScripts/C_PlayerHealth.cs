using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class C_PlayerHealth : MonoBehaviour, IDataPersistence
{
    public C_PlayerController player;

    public Animator animator;

    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    public int currentHealth;
    public int PlayerLives;

    private GameObject shield;
    int hits = 3;

    private bool isRespawning;
    private Vector3 respawnPoint;

    public bool isColliding;

    //public float Invicablitylength;
    //
    //private float InvicablityCounter;

    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;
    public AudioSource audioSource;

    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;

    public GameObject HealthUI1, HealthUI2, HealthUI3;

    public PlayerBlock playerBlock;


    //public bool 

    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        //PlayerLives = 3;

       //respawnPoint = player.transform.position;

       shield = transform.Find("Shield").gameObject;
       shield.SetActive(false);
    }

    public void LoadData(GameData data)
    {
        this.currentHealth = data.PlayerCurrentHealth;
        this.PlayerLives = data.PlayerCurrentLives;
    }

    public void SaveData(GameData data)
    {
        data.PlayerCurrentHealth = this.currentHealth;
        data.PlayerCurrentLives = this.PlayerLives;
    }

    void Update()
    {
        //if(InvicablityCounter > 0)
        //{
        //    InvicablityCounter -= Time.deltaTime;
        //    TimerCanvas.SetActive(true);
        //}
        //else
        //{
        //    TimerCanvas.SetActive(false);
        //}

        Timmer();
        PlayerLoss();
        PlayerDeath();

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        isColliding = false;
    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;
                TimerCanvas.SetActive(false);

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerUI.text = "invincibility Frames: " + string.Format("{0:0}", seconds);

    }

    void OnTriggerEnter(Collider collision)
    {
        if (TimeLeft <= 0)
        {
            if (isColliding) return;
            isColliding = true;

            if(playerBlock.IsBlocking == false)
            {
                if (collision.gameObject.tag == "EnemyWeapon")
                {
                    ChangeHealth(-1);
                    audioSource.Play();
                    animator.SetTrigger("Hurt 0");
                    
                    if (shield.activeInHierarchy)
                   {
                        if (hits > 1)
                        {
                            shield.SetActive(true);
                            hits -= 1;
                        }
                        else
                        {
                            shield.SetActive(false);
                        }
                   } 
                   else
                   {
                       TimerOn = true;
                       TimeLeft = SetCoolDownTime;
                       ChangeHealth(-1);
                   }
                }
                
                if (collision.gameObject.tag == "Shield")
                {
                   shield.SetActive(true);
                   Destroy(collision.gameObject);
                }

            }
            else
            {
                animator.SetTrigger("IsBlockingHit");
                if (collision.gameObject.tag == "EnemyWeapon")
                {
                    player.CurrentStamina -= 1;
                }

            }

        }
    }

    //public void EnemyWepDam()
    //{
    //    currentHealth -= 1;
    //}

    public void ChangeHealth(int amount)
    {
        if (currentHealth == 0)
        {
            PlayerLives -= 1;
            Respwan();
            
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }



    public void Respwan()
    {
        Debug.Log("PlayerRespawned");
        player.transform.position = respawnPoint;
        currentHealth = maxHealth;
        
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

    public void PlayerLoss()
    {
        if(PlayerLives == 0)
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }

    public void PlayerDeath()
    {
        if (PlayerLives <= 2)
        {
            HealthUI3.SetActive(false);
        }
        else
        {
            HealthUI3.SetActive(true);
        }

        if (PlayerLives <= 1)
        {
            HealthUI2.SetActive(false);
        }
        else
        {
            HealthUI2.SetActive(true);
        }

        if (PlayerLives <= 0)
        {
            HealthUI1.SetActive(false);
        }
        else
        {
            HealthUI1.SetActive(true);
        }



    }
}
