using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicVol : MonoBehaviour
{
    public AudioSource BgMusic;
    void Start()
    {
        BgMusic.volume = PlayerPrefs.GetFloat("VolumePref");
    }
}
