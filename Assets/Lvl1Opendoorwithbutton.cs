using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Opendoorwithbutton : MonoBehaviour
{
    public Level1SideQuestManager questManager;

    public GameObject ClosedDoor;
    public GameObject OpenDoor;

    void OnCollisionEnter(Collision col)
    {


        if (col.collider.tag == "NotActive")
        {
            questManager.Quest5_1Complete = true;
            ClosedDoor.SetActive(false);
            OpenDoor.SetActive(true);
        }

    }
}
