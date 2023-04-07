using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LV2Intro : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public string SceneName;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction SkipAction;

    public float SkipCount;
    public bool SKipPressed;


    private void Awake()
    {
        SkipAction = playerInput.actions["SkipCutsceen"];
    }
    void Start()
    {
        VideoPlayer.SetDirectAudioVolume(0, PlayerPrefs.GetFloat("diagvolpref"));
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("Level 2");
    }

    private void Update()
    {
        if (SkipCount >= 5) { SceneManager.LoadScene("Level 2"); }

        if (SkipCount <= 0)
        {
            SkipCount = 0;
        }

        if (SKipPressed == true)
        {
            SkipCount += Time.deltaTime;
        }
        else
        {
            SkipCount -= Time.deltaTime;
        }

    }


    private void OnEnable()
    {
        SkipAction.performed += _ => StartSkip();
        SkipAction.canceled += _ => CancelSkip();


    }

    private void OnDisable()
    {
        SkipAction.performed -= _ => StartSkip();
        SkipAction.canceled -= _ => CancelSkip();

    }

    public void StartSkip()
    {
        if (SceneManager.GetActiveScene().name == "Lv2 intro")
        {

             //SKipPressed = true;
             Debug.Log("Skip Button Pressed");
         SceneManager.LoadScene("Level 2");
        }
    }

    public void CancelSkip()
    {
        SKipPressed = false;
    }
}
