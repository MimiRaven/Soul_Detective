using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
   private static readonly string VolumePref = "VolumePref";
    private static readonly string SoundEffectPref = "SoundEffectPref";

    private float volumeFloat;
    private float soundEffectFloat;
    public AudioSource masterAudio;
    public AudioSource [] soundEffectAudio;
    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        volumeFloat = PlayerPrefs.GetFloat(VolumePref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        masterAudio.volume = volumeFloat;

        for(int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectFloat;
        }
    }
}