using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LV3outro : MonoBehaviour
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
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("Win Screen");
    }

    private void Update()
    {
        if (SkipCount >= 5) { SceneManager.LoadScene("Win Screen"); }

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
        if (SceneManager.GetActiveScene().name == "Lv3 outro")
        {

                //SKipPressed = true;
                Debug.Log("Skip Button Pressed");
            SceneManager.LoadScene("Win Screen");
        }
    }

    public void CancelSkip()
    {
        SKipPressed = false;
    }
}