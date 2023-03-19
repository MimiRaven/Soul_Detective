using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionTracker : MonoBehaviour, IDataPersistence
{
    //public Vector3 PositionInHubworld;
    //
    //public Vector3 PositionInLevel1;
    //public Vector3 PositionInLevel2;
    //public Vector3 PositionInLevel3;

    public Transform HubSpawnPoint;
    public Transform Level1SpawnPoint;
    public Transform Level2SpawnPoint;
    public Transform Level3SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {

      //if (!DataPersistenceManager.instance.HasGameData())
      //{
      //    
      //}

        //Undo
       // if (SceneManager.GetActiveScene().name == "HubWorld")
       // {
       //     this.transform.position = HubSpawnPoint.transform.position;
       //
       // }
       //
       // if (SceneManager.GetActiveScene().name == "Level 1")
       // {
       //     this.transform.position = Level1SpawnPoint.transform.position;
       // }
       //
       //
       // if (SceneManager.GetActiveScene().name == "Level 2")
       // {
       //     this.transform.position = Level2SpawnPoint.transform.position;
       // }
       //
       //
       // if (SceneManager.GetActiveScene().name == "Level 3")
       // {
       //     this.transform.position = Level3SpawnPoint.transform.position;
       // }
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void LoadData(GameData data)
    {
       //this.PositionInHubworld = data.playerPositionInHubWorld;
       //this.PositionInLevel1 = data.playerPositionInLevel1;
       //this.PositionInLevel2 = data.playerPositionInLevel2;
       //this.PositionInLevel3 = data.playerPositionInLevel3;


        //Undo
       //if (SceneManager.GetActiveScene().name == "HubWorld")
       //{
       //    this.transform.position = data.playerPositionInHubWorld;
       //
       //}
       //
       //if (SceneManager.GetActiveScene().name == "Level 1")
       //{
       //    this.transform.position = data.playerPositionInLevel1;
       //}
       //
       //
       //if (SceneManager.GetActiveScene().name == "Level 2")
       //{
       //    this.transform.position = data.playerPositionInLevel2;
       //}
       //
       //
       //if (SceneManager.GetActiveScene().name == "Level 3")
       //{
       //    this.transform.position = data.playerPositionInLevel3;
       //}
    }

    public void SaveData(GameData data)
    {
       //data.playerPositionInHubWorld = this.PositionInHubworld;
       //data.playerPositionInLevel1 = this.PositionInLevel1;
       //data.playerPositionInLevel2 = this.PositionInLevel2;
       //data.playerPositionInLevel3 = this.PositionInLevel3;



        //Undo
       //if (SceneManager.GetActiveScene().name == "HubWorld")
       //{
       //    data.playerPositionInHubWorld = this.transform.position;
       //
       //}
       //
       //if (SceneManager.GetActiveScene().name == "Level 1")
       //{
       //    data.playerPositionInLevel1 = this.transform.position;
       //
       //}
       //
       //
       //if (SceneManager.GetActiveScene().name == "Level 2")
       //{
       //    data.playerPositionInLevel2 = this.transform.position;
       //
       //}
       //
       //
       //if (SceneManager.GetActiveScene().name == "Level 3")
       //{
       //    data.playerPositionInLevel3 = this.transform.position;
       //
       //}
       //
    }



}
