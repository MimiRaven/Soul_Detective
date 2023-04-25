using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTextAlert : MonoBehaviour
{
    public Diolouge Npcdiologe;

    public GameObject Text;

    public float TimeLeft;
    public bool TimerOn;

    public float TalkCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timmer();

        if (Npcdiologe.TextEnded == true)
        {
            TalkCheck += 1;
            TimeLeft = 3;
        }

        if (TalkCheck == 1)
        {
            TimerOn = true;
            
        }
    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                Text.SetActive(true);
                // TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;
                Text.SetActive(false);
                //Text.SetActive(false);
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
