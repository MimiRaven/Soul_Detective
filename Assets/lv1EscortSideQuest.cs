using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv1EscortSideQuest : MonoBehaviour
{
    public Diolouge Npcdiologe;
    public GameObject StartingNpc;

    public GameObject EscortedNpc;
    public GameObject QuestPrize;

    public bool NpcCollected;

    public Level1SideQuestManager Level1SideQuestManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Npcdiologe.TextEnded == true)
        {
            NpcCollected = true;
            StartingNpc.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("EscortEnd"))
        {
            if (NpcCollected == true)
            {
               // EscortedNpc.SetActive(true);
                QuestPrize.SetActive(true);
                Level1SideQuestManager.EscortQuest = true; 
            }


        }
    }
}
