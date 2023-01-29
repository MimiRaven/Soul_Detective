using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_VirticalKey : MonoBehaviour
{

    public GameObject Self;
    public GameObject Door;
    public GameObject OtherEnemy;

    public float TimeLeft;
    public bool TimerOn;

    //public C_EnemyPossesed c_EnemyPossesed;
    // Start is called before the first frame update
    void Start()
    {
        OtherEnemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft == 0)
        {
            Destroy(gameObject);
            OtherEnemy.SetActive(true);
        }

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
                //TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                TimeLeft = 0;
                

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        //TimerUI.text = string.Format("{0:0}", seconds);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log("Key Touched");
            //c_EnemyPossesed.Possesed = false;
           // Self.SetActive(false);
            Door.SetActive(false);
            //OtherEnemy.SetActive(true);
            TimerOn = true;
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }
}
