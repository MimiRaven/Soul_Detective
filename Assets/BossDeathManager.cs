using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathManager : MonoBehaviour, IDataPersistence
{
    public Level2SideQuestManager SideQuestManager;
    public bool Boss1Dead;
    public GameObject Boss1Door;

    public bool Boss2Dead;
    public GameObject Boss2Door;


    public GameObject HellDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LoadData(GameData data)
    {
        this.Boss1Dead = data.LV2Boss1Dead;
        this.Boss2Dead = data.LV2Boss2Dead;
    }

    public void SaveData(GameData data)
    {
       data.LV2Boss1Dead = this.Boss1Dead;
        data.LV2Boss2Dead = this.Boss2Dead;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss1Dead)
        {
            Boss1Door.SetActive(false);
            SideQuestManager.RightBossDead= true;

        }
        if (Boss2Dead)
        {
            Boss2Door.SetActive(false);
            SideQuestManager.LeftBossDead= true;
        }

        if(Boss1Dead && Boss2Dead == true)
        {
            HellDoor.SetActive(false);
        }
    }
}
