using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSlider : MonoBehaviour
{
    public Slider fontslider;
    public float ScaleForpause;
    // Start is called before the first frame update
    void Start()
    {
        fontslider.value = PlayerPrefs.GetFloat("FontSize");
    }

    public void SliderChange()
    {
        PlayerPrefs.SetFloat("FontSize", fontslider.value);
        ScaleForpause = fontslider.value / 24;
        PlayerPrefs.SetFloat("mutiplescale", ScaleForpause);
    }
}
