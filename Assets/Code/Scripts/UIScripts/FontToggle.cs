using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontToggle : MonoBehaviour
{
    public Toggle fontstoggle;//link to UI object
    public GameObject warningtxt;
    public void Start()//sets starting state
    {
        if (PlayerPrefs.GetInt("FontSizeON") == 0)//custom font on
        {
            fontstoggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("FontSizeON") == 1)//custom font off
        {
            fontstoggle.isOn = false;
        }
        else//backup, defaults to standard size
        {
            fontstoggle.isOn = false;
            PlayerPrefs.SetInt("FontSizeON", 1);
            warningtxt.SetActive(true);
        }

    }

    public void fontupdate()//when the toggle is pressed
    {
        if (fontstoggle.isOn == true)
        {
            warningtxt.SetActive(false);
            PlayerPrefs.SetInt("FontSizeON", 0);
            Debug.Log("arin sizes will be on");
        }
        else
        {
            PlayerPrefs.SetInt("FontSizeON", 1);
            Debug.Log("arin sizes will be off");
            warningtxt.SetActive(true);

        }
    }


    
}
