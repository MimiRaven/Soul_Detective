using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject MainMenu;

    public static LoadScene Instance;

    //public Image LoadingBarFill;

    [SerializeField] private CurrentSceneManager currentSceneManager;

    [SerializeField] private SaveSlotsMenu saveSlots;

    //public Slider slider;

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
        MainMenu.SetActive(false);

        if (saveSlots.isLoadingGame == false)
        {
            AsyncOperation FirstCutscene = SceneManager.LoadSceneAsync("Lv1 intro");

            while (!FirstCutscene.isDone)
            {
                float progressValue = Mathf.Clamp01(FirstCutscene.progress / 0.9f);
               // slider.value = progressValue;

                //LoadingBarFill.fillAmount= progressValue;

                yield return null;
            }
        }


        if (currentSceneManager.CurerntlyInHubWorld == true)
        {
            AsyncOperation HunWorld = SceneManager.LoadSceneAsync("HubWorld");

            while (!HunWorld.isDone)
            {
                float progressValue = Mathf.Clamp01(HunWorld.progress / 0.9f);
                //slider.value = progressValue;

                yield return null;
            }

        }

        if (currentSceneManager.CurrentlyInLevel1 == true)
        {
            AsyncOperation Level1 = SceneManager.LoadSceneAsync("Level 1");

            while (!Level1.isDone)
            {
                float progressValue = Mathf.Clamp01(Level1.progress / 0.9f);
              //  slider.value = progressValue;

                yield return null;
            }

        }

        if (currentSceneManager.CurrentlyInLevel1 == true)
        {
            AsyncOperation Level1 = SceneManager.LoadSceneAsync("Level 1");

            while (!Level1.isDone)
            {
                float progressValue = Mathf.Clamp01(Level1.progress / 0.9f);
               // slider.value = progressValue;

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
               // slider.value = progressValue;

                yield return null;
            }

        }



        // AsyncOperation operation = SceneManager.LoadSceneAsync("Lv1 intro");
        //
        // while (!operation.isDone)
        // {
        //     float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
        //
        //     yield return null;
        // }

    }
}
