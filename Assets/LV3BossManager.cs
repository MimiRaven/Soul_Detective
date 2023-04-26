using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV3BossManager : MonoBehaviour
{
    public Level3SideQuestManager SideQuestManager;

    public bool Boss1Dead;
    public bool Boss2Dead;
    public bool Boss3Dead;

    public GameObject BossDoor;

    public GameObject Text;
    public float TimeLeft;
    public bool TimerOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Timmer();


        if (Boss1Dead)
        {
            SideQuestManager.Boss1Dead = true;
        }
        if(Boss2Dead)
        {
            SideQuestManager.Boss2Dead = true;

        }
        if(Boss3Dead)
        {
            SideQuestManager.Boss3Dead= true;
        }

        if(Boss1Dead && Boss2Dead && Boss3Dead)
        {
            BossDoor.SetActive(false);
            SideQuestManager.AllMiniBossesDead= true;
            
            TimerOn = true;
            //TimeLeft = 5;
            //SceneManager.LoadScene("HubWorld");
        }
    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                Text.SetActive(true);
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                // TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                
                TimerOn = false;
                Text.SetActive(false);
       
                //TimerCanvas.SetActive(false);

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        //TimerUI.text = "Range Cooldown: " + string.Format("{0:0}", seconds);

    }
}
