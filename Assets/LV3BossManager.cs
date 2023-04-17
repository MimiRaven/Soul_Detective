using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV3BossManager : MonoBehaviour
{
    public Level3SideQuestManager SideQuestManager;

    public bool Boss1Dead;
    public bool Boss2Dead;
    public bool Boss3Dead;

    public GameObject BossDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss1Dead)
        {
            SideQuestManager.Boss1Dead = true;
        }
        if(Boss2Dead)
        {
            SideQuestManager.Boss2Dead = true;

        }
        if(Boss3Dead)
        {
            SideQuestManager.Boss3Dead= true;
        }

        if(Boss1Dead && Boss2Dead && Boss3Dead)
        {
            BossDoor.SetActive(false);
            SideQuestManager.AllMiniBossesDead= true;
            //SceneManager.LoadScene("HubWorld");
        }
    }
}
