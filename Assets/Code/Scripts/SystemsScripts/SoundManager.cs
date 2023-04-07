using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
   private static readonly string FirstPlay = "FirstPlay";
    private static readonly string VolumePref = "VolumePref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;
    [SerializeField]private Slider volumeSlider;
    [SerializeField]private Slider soundEffectSlider;
    private float volumeFloat;
    private float soundEffectFloat;
    public AudioSource masterAudio;
    public AudioSource [] soundEffectAudio;
    //arin dialog volume stuff
    float diagvol;
    public Slider diagvolslider;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            volumeFloat = .125f;
            soundEffectFloat = .75f;
            volumeSlider.value = volumeFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(VolumePref, volumeFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

        else
        {
            volumeFloat = PlayerPrefs.GetFloat(VolumePref);
            volumeSlider.value = volumeFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;
            diagvolslider.value = PlayerPrefs.GetFloat("diagvolpref");
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePref,  volumeSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        masterAudio.volume = volumeSlider.value;

        for(int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectSlider.value;
        }
    }
    //arin method for dialog sound updates
    public void UpdateDiag()
    {
        //diagvol = diagvolslider.value;
        PlayerPrefs.SetFloat("diagvolpref", diagvolslider.value);
    }
}