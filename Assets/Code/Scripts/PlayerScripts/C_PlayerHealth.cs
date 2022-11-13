using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class C_PlayerHealth : MonoBehaviour
{
    public C_PlayerController player;

    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    public int currentHealth;

    private bool isRespawning;
    private Vector3 respawnPoint;

    public bool isColliding;

   //public float Invicablitylength;
   //
   //private float InvicablityCounter;

    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;

    public float SetCoolDownTime;
    private float TimeLeft;
    public bool TimerOn;

    //public bool 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        respawnPoint = player.transform.position;
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
    
              if (collision.gameObject.tag == "EnemyWeapon")
              {

                TimerOn = true;
                TimeLeft = SetCoolDownTime;
                ChangeHealth(-1);
                
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
            Respwan();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }



    public void Respwan()
    {
        Debug.Log("PlayerRespawned");
        player.transform.position = respawnPoint;
        currentHealth = maxHealth;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
