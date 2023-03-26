using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_OpenDoorWithTeleButton : MonoBehaviour
{
    public Level2SideQuestManager Level2SideQuestManager;
    public GameObject ClosedDoor;
    public GameObject OpenDoor;

    public GameObject SideQuest1Text;
    public GameObject CompleteQuest1Text;
    public GameObject QuestionMarks;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {


        if (col.collider.tag == "GreenBox")
        {
            Level2SideQuestManager.Quest2Complete = true;

           //ClosedDoor.SetActive(false);
           //OpenDoor.SetActive(true);
           //
           //SideQuest1Text.SetActive(false);
           //QuestionMarks.SetActive(false);
           //CompleteQuest1Text.SetActive(true);
        }
    }
}
