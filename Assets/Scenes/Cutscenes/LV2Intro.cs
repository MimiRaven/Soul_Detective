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

    public GameObject LoadingScreen;
    public static LV2Intro Instance;

    //clip references
    public VideoClip subs;
    public VideoClip nosubs;

    private void Awake()
    {
        SkipAction = playerInput.actions["SkipCutsceen"];
        if (PlayerPrefs.GetInt("subsON") == 0)
        {
            VideoPlayer.clip = subs;
        }
        else
        {
            VideoPlayer.clip = nosubs;
        }
        if (Instance == null)
        {
            Instance = this;
            //  DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        VideoPlayer.SetDirectAudioVolume(0, PlayerPrefs.GetFloat("diagvolpref"));
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        StartCoroutine(LoadSceneAsync("Level 2"));
    }
    public IEnumerator LoadSceneAsync(string sceneName)
    {
        LoadingScreen.SetActive(true);

        AsyncOperation Lv2 = SceneManager.LoadSceneAsync("Level 2");

        while (!Lv2.isDone)
        {

            float progressValue = Mathf.Clamp01(Lv2.progress / 0.9f);
            // slider.value = progressValue;

            //LoadingBarFill.fillAmount= progressValue;

            yield return null;
        }
    }
    private void Update()
    {
        if (SkipCount >= 5) { StartCoroutine(LoadSceneAsync("Level 2")); }

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
            VideoPlayer.Pause();
             //SKipPressed = true;
             Debug.Log("Skip Button Pressed");
            StartCoroutine(LoadSceneAsync("Level 2"));
        }
    }

    public void CancelSkip()
    {
        SKipPressed = false;
    }
}
