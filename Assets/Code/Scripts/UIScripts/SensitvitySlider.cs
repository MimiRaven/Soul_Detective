using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitvitySlider : MonoBehaviour
{
    //references to the UI sliders that will change the setting
    public Slider hslider;
    public Slider vslider;

    //temp floats of the sensitivity level
    float hsliderlevel;
    float vsliderlevel;

    void Start()
    {
        //sets the sliders to the current saved levels for UI purposes
        hslider.value = PlayerPrefs.GetFloat("Hsensitvity");
        vslider.value = PlayerPrefs.GetFloat("Vsensitvity");
    }

    //method to change the horziontal slider/value
    public void changesliderH()
    {
        hsliderlevel = hslider.value;
        PlayerPrefs.SetFloat("Hsensitvity", hsliderlevel); 
    }

    //method to change the vertical slider/value
    public void changesliderV()
    {
        vsliderlevel = vslider.value;
        PlayerPrefs.SetFloat("Vsensitvity", vsliderlevel); 
    }
}
