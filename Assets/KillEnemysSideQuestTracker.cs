using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class KillEnemysSideQuestTracker : MonoBehaviour
{
    public int EnemysKilled;
    public Level2SideQuestManager Level2SideQuestManager;

    public GameObject PuzzleAreaTrigger;
    public GameObject PuzzleDoor;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemysKilled >= 5)
        {
            Level2SideQuestManager.KillingEnemyQuest = true;
        }

        if(Level2SideQuestManager.KillingEnemyQuest == true)
        {
            PuzzleDoor.SetActive(false);
            PuzzleAreaTrigger.SetActive(false);
        }
        
    }

   //private void OnTriggerEnter(Collider other)
   //{
   //    if (other.CompareTag("LV2PuzzleArea"))
   //    {
   //        PuzzleDoor.SetActive(true);
   //    }
   //}
}
