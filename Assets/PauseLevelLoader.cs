using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public static PauseLevelLoader Instance;
    public C_PauseManager PausegManager;
    void Awake()
    {
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

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        LoadingScreen.SetActive(true);


        if (PausegManager.GoToHub == true)
        {
            AsyncOperation HubWorld = SceneManager.LoadSceneAsync("HubWorld");

            while (!HubWorld.isDone)
            {
                Debug.Log("Hub Is Loading");
                float progressValue = Mathf.Clamp01(HubWorld.progress / 0.9f);
                // slider.value = progressValue;

                //LoadingBarFill.fillAmount= progressValue;

                yield return null;
            }
        }

        if (PausegManager.GoToMainMenu == true)
        {
            AsyncOperation MainMenu = SceneManager.LoadSceneAsync("Main Menu");

            while (!MainMenu.isDone)
            {
                float progressValue = Mathf.Clamp01(MainMenu.progress / 0.9f);
                // slider.value = progressValue;

                //LoadingBarFill.fillAmount= progressValue;

                yield return null;
            }
        }
    }
}
