using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour, IDataPersistence
{

    public bool CurerntlyInHubWorld;

    public bool CurrentlyInLevel1;
    public bool CurrentlyInLevel2;
    public bool CurrentlyInLevel3;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "HubWorld")
        {
            CurerntlyInHubWorld = true;

            CurrentlyInLevel1 = false;
            CurrentlyInLevel2 = false;
            CurrentlyInLevel3 = false;

        }

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            CurrentlyInLevel1 = true;
            CurerntlyInHubWorld = false;
            
            CurrentlyInLevel2 = false;
            CurrentlyInLevel3 = false;
        }


        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            CurrentlyInLevel1 = false;
            CurerntlyInHubWorld = false;

            CurrentlyInLevel2 = true;
            CurrentlyInLevel3 = false;
        }


        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            CurrentlyInLevel1 = false;
            CurerntlyInHubWorld = false;

            CurrentlyInLevel2 = false;
            CurrentlyInLevel3 = true;
        }
    }

    public void LoadData(GameData data)
    {
        this.CurerntlyInHubWorld = data.InHubWorld;
        this.CurrentlyInLevel1 = data.InLevel1;
        this.CurrentlyInLevel2 = data.InLevel2;
        this.CurrentlyInLevel3 = data.InLevel3;
    }

    public void SaveData(GameData data)
    {
        data.InHubWorld = this.CurerntlyInHubWorld;
        data.InLevel1 = this.CurrentlyInLevel1;
        data.InLevel2 = this.CurrentlyInLevel2;
        data.InLevel3 = this.CurrentlyInLevel3;
    }
}
