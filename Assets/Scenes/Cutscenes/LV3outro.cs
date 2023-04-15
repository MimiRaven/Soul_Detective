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

    public GameObject LoadingScreen;
    public static LV3intro Instance;


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
        StartCoroutine(LoadSceneAsync("Win Screen"));
    }

    private void Update()
    {
        if (SkipCount >= 5) { StartCoroutine(LoadSceneAsync("Win Screen")); }

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

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        LoadingScreen.SetActive(true);

        AsyncOperation WinScreen = SceneManager.LoadSceneAsync("Win Screen");

        while (!WinScreen.isDone)
        {

            float progressValue = Mathf.Clamp01(WinScreen.progress / 0.9f);
            // slider.value = progressValue;

            //LoadingBarFill.fillAmount= progressValue;

            yield return null;
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
            StartCoroutine(LoadSceneAsync("Win Screen"));
        }
    }

    public void CancelSkip()
    {
        SKipPressed = false;
    }
}
