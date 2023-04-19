using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleToggle : MonoBehaviour
{
    public Toggle substoggle;//link to UI object
    public void Start()//sets starting state
    {
        if (PlayerPrefs.GetInt("subsON") == 0)//subs on
        {
            substoggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("subsON") == 1)//subs off
        {
            substoggle.isOn = false;
        }
        else//backup, defaults to subs on
        {
            substoggle.isOn = true;
            PlayerPrefs.SetInt("subsON", 0);
        }

    }

    public void subupdate()//when the toggle is pressed
    {
        if (substoggle.isOn == true)
        {
            PlayerPrefs.SetInt("subsON", 0);
            Debug.Log("arin subs are on");
        }
        else
        {
            PlayerPrefs.SetInt("subsON", 1);
            Debug.Log("arin subs are off");
        }
    }
}
