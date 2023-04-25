using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAlertPopUp : MonoBehaviour
{
    public GameObject Text;
    public GameObject combatText;
    public GameObject CatacombText;
    public GameObject BossText;

    public bool Text1;
    public bool Text2;
    public bool Text3;
    public bool Text4;

    //public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;

  //public bool firstInteracted;
  //public bool SecondInteracted;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timmer();
    }
    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                // TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                TimeLeft = 3;
                TimerOn = false;
                Text.SetActive(false);
                combatText.SetActive(false);
                CatacombText.SetActive(false);
                BossText.SetActive(false);
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
    void OnTriggerEnter(Collider other)
    {
        if(Text1 == false)
        {
            if (other.CompareTag("TextPop"))
            {
                Text.SetActive(true);
                TimerOn = true;
                TimeLeft = 3;
                combatText.SetActive(false) ;
                CatacombText.SetActive(false);
                BossText.SetActive(false);
                Text1 = true;
            }
    
        }


        if (Text2 == false)
        {
             if (other.CompareTag("TextPop2"))
             {
             combatText.SetActive(true);
             TimerOn = true;
             TimeLeft = 3;
             Text.SetActive(false);
             BossText.SetActive(false);
             CatacombText.SetActive(false);
                Text2 = true;
             }

        }

        if (Text3 == false)
        {
              if (other.CompareTag("TextPop3"))
             {
              CatacombText.SetActive(true);
              TimerOn = true;
              TimeLeft = 3;
              Text.SetActive(false);
              combatText.SetActive(false);
              BossText.SetActive(false);
                Text3 = true;
             }

        }

        if(Text4 == false)
        {

          if (other.CompareTag("TextPop4"))
          {
              BossText.SetActive(true);
              TimerOn = true;
              TimeLeft = 3;
              Text.SetActive(false);
              combatText.SetActive(false);
              CatacombText.SetActive(false);
                Text4 = true;
          }
        
        }

    }
}
