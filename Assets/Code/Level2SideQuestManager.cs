using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SideQuestManager : MonoBehaviour
{
    public bool Quest1Complete;
    public bool Quest2Complete;
    public bool Quest3Complete;
    public bool Quest4Complete;
    public bool Quest5Complete;
    public bool Quest5_1Complete;

    [Header("Quest 1 Variables")]
    //public GameObject Q1ClosedGate;
    public GameObject Debris;
    public GameObject Q1SideQuest1Text;
    public GameObject Q1CompleteQuest1Text;
    public GameObject Q1QuestionMarks;

    [Header("Quest 2 Variables")]
    public GameObject Q2ClosedGate;
    public GameObject Q2OpenGate;
    public GameObject Q2SideQuest1Text;
    public GameObject Q2CompleteQuest1Text;
    public GameObject Q2QuestionMarks;
    //public GameObject Q2KeyObject;

    [Header("Quest 3 Variables")]
    public GameObject Q3ClosedGate;
    public GameObject Q3OpenGate;
    public GameObject Q3SideQuest1Text;

    public GameObject Q3CompleteQuest1Text;
    public GameObject Q3QuestionMarks;
    public GameObject Hazard;

    [Header("Quest 4 Variables")]
   // public GameObject Q4Door;
    public GameObject Q4SideQuest1Text;
    public GameObject Q4CompleteQuest1Text;
    public GameObject Q4QuestionMarks;
    public GameObject Q4KeyObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        QuestUpdate();
    }

    public void QuestUpdate()
    {
        if (Quest1Complete == true)
        {

            //Q1ClosedGate.SetActive(false);
            //Q1OpenGate.SetActive(true);

            Q1SideQuest1Text.SetActive(false);
            Q1CompleteQuest1Text.SetActive(true);
            Q1QuestionMarks.SetActive(false);
            Debris.SetActive(false);
        }

        if (Quest2Complete == true)
        {
            Q2ClosedGate.SetActive(false);
            Q2OpenGate.SetActive(true);

            Q2SideQuest1Text.SetActive(false);
            Q2CompleteQuest1Text.SetActive(true);
            Q2QuestionMarks.SetActive(false);
            //Q2KeyObject.SetActive(false);
        }

        if (Quest3Complete == true)
        {
            Q3ClosedGate.SetActive(false);
            Q3OpenGate.SetActive(true);

            Q3SideQuest1Text.SetActive(false);
            Q3CompleteQuest1Text.SetActive(true);
            Q3QuestionMarks.SetActive(false);
            Hazard.SetActive(false);

        }

        if (Quest4Complete)
        {

            //Q4Door.SetActive(false);

            Q4KeyObject.SetActive(false);

            Q4SideQuest1Text.SetActive(false);
            Q4CompleteQuest1Text.SetActive(true);
            Q4QuestionMarks.SetActive(false);
           
        }

    }
}
