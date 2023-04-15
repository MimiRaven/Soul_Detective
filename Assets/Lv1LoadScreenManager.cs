using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lv1LoadScreenManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public static Lv1LoadScreenManager Instance;
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

  // public IEnumerator LoadSceneAsync(string sceneName)
  // {
  //     LoadingScreen.SetActive(true);
  //     
  //
  //    //if (saveSlots.isLoadingGame == false)
  //    //{
  //    //    AsyncOperation FirstCutscene = SceneManager.LoadSceneAsync("Lv1 intro");
  //    //
  //    //    while (!FirstCutscene.isDone)
  //    //    {
  //    //        float progressValue = Mathf.Clamp01(FirstCutscene.progress / 0.9f);
  //    //        // slider.value = progressValue;
  //    //
  //    //        //LoadingBarFill.fillAmount= progressValue;
  //    //
  //    //        yield return null;
  //    //    }
  //    //}
  // }
} //
