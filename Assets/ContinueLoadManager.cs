using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueLoadManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject MainMenu;

    public static ContinueLoadManager Instance;

    //public Slider slider;

    [SerializeField] private CurrentSceneManager currentSceneManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);

        if (currentSceneManager.CurerntlyInHubWorld == true)
        {
            AsyncOperation HunWorld = SceneManager.LoadSceneAsync("HubWorld");

            while (!HunWorld.isDone)
            {
                float progressValue = Mathf.Clamp01(HunWorld.progress / 0.9f);

             //   slider.value = progressValue;

                yield return null;
            }

        }

        if (currentSceneManager.CurrentlyInLevel1 == true)
        {
            AsyncOperation Level1 = SceneManager.LoadSceneAsync("Level 1");

            while (!Level1.isDone)
            {
                float progressValue1 = Mathf.Clamp01(Level1.progress / 0.9f);
              //  slider.value = progressValue1;

                yield return null;
            }

        }


        if (currentSceneManager.CurrentlyInLevel2 == true)
        {
            AsyncOperation Level2 = SceneManager.LoadSceneAsync("Level 2");


            while (!Level2.isDone)
            {
                float progressValue = Mathf.Clamp01(Level2.progress / 0.9f);
              //  slider.value = progressValue;

                yield return null;
            }

        }

        if (currentSceneManager.CurrentlyInLevel3 == true)
        {
            AsyncOperation Level3 = SceneManager.LoadSceneAsync("Level 3");

            while (!Level3.isDone)
            {
                float progressValue = Mathf.Clamp01(Level3.progress / 0.9f);
              //  slider.value = progressValue;

                yield return null;
            }

        }
    }
}
