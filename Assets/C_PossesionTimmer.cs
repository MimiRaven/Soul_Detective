using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class C_PossesionTimmer : MonoBehaviour
{
    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;
    public C_PlayerController c_PlayerController;


    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;


    // Start is called before the first frame update
    void Start()
    {
        //TimeLeft = SetCoolDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(TimeLeft>= 0)
        {
            //c_PlayerController.Possesed = true;
           
        }

       //if(c_PlayerController.Possesed == true)
       //{
       //    TimerOn= false;
       //}

        Timmer();
    }

    void Timmer()
    {

        if (TimerOn)
        {
            c_PlayerController.Possesed = false;

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                TimerCanvas.SetActive(true);
                //c_PlayerController.Possesed = false;
                
            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;
                TimerCanvas.SetActive(false);
                // TimeLeft = SetCoolDownTime;
                //c_PlayerController.Possesed = true;
                //TimeLeft = SetCoolDownTime;
               // c_PlayerController.Possesed = true;

            }

        }
        else
        {
            TimerCanvas.SetActive(false);
            TimeLeft = SetCoolDownTime;
           
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerUI.text = "Possesion Timmer: " + string.Format("{0:0}", seconds);

    }
}
