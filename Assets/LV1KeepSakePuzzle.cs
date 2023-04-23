using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV1KeepSakePuzzle : MonoBehaviour
{
    public Level1SideQuestManager level1SideQuestManager;
    public GameObject KeepSakeItem;

    public bool KeepSakeObtained;

    public GameObject QuestPrize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("KeepSake"))
        {
            KeepSakeItem.SetActive(false);
            KeepSakeObtained= true;

        }

        if (other.CompareTag("KeepSakeFinishArea"))
        {
            if(KeepSakeObtained)
            {
                level1SideQuestManager.KeepSakeQuest = true;
                QuestPrize.SetActive(true);
            }
        }
    }
}
