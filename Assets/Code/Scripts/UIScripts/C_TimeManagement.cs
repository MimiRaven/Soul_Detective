using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TimeManagement : MonoBehaviour
{
    public bool TimeStop;

    void Awake()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(TimeStop == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
