using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DetroyObjectWithTeleButton : MonoBehaviour
{
    public Level2SideQuestManager SideQuestManager;

    public GameObject HazardObject;

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


        if (col.collider.tag == "NotActive")
        {
            SideQuestManager.Quest1Complete= true;

          //HazardObject.SetActive(false);
          //SideQuest1Text.SetActive(false);
          //CompleteQuest1Text.SetActive(true);
          //QuestionMarks.SetActive(false);
        }
    }
 }
