using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1SideQuestManager : MonoBehaviour, IDataPersistence
{

    public bool Quest1Complete;
    public bool Quest2Complete;
    public bool Quest3Complete;
    public bool Quest4Complete;
    public bool Quest5Complete;
    public bool Quest5_1Complete;



    [Header("Main Objective Variables")]
    public bool BossDead;

    [Header("Quest 1 Variables")]
    //public GameObject Q1ClosedGate;
    public GameObject BrokenFence;
    public GameObject Q1SideQuest1Text;
    public GameObject Q1CompleteQuest1Text;
    public GameObject Q1QuestionMarks;

    [Header("Quest 2 Variables")]
    public GameObject Q2ClosedGate;
    public GameObject Q2OpenGate;
    public GameObject Q2SideQuest1Text;
    public GameObject Q2CompleteQuest1Text;
    public GameObject Q2QuestionMarks;
    public GameObject Q2KeyObject;

    [Header("Quest 3 Variables")]
    public GameObject Q3ClosedGate;
    public GameObject Q3OpenGate;
    public GameObject Q3SideQuest1Text;
        
    public GameObject Q3CompleteQuest1Text;
    public GameObject Q3QuestionMarks;
    public GameObject Q3KeyObject;

    [Header("Quest 4 Variables")]
    public GameObject Q4Door;
    public GameObject Q4SideQuest1Text;
    public GameObject Q4CompleteQuest1Text;
    public GameObject Q4QuestionMarks;
    public GameObject Q4KeyObject;

    [Header("Quest 5 Variables")]
     public GameObject Q5Door;
    public GameObject Q5Door2;


    public GameObject Q5SideQuest1Text;
    public GameObject Q5CompleteQuest1Text;
    public GameObject Q5QuestionMarks;
     public GameObject Q5KeyObject;


    [Header("Keep Sake Quest ")]
    public bool KeepSakeQuest;
    public GameObject KSSideQuest1Text;
    public GameObject KSCompleteQuest1Text;
    public GameObject KSQuestionMarks;

    [Header("Escory Quest ")]
    public bool EscortQuest;
    public GameObject EscortSideQuest1Text;
    public GameObject EscortCompleteQuest1Text;
    public GameObject EscortQuestionMarks;
    public GameObject EscortedNpc;
    public GameObject StartNpc;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadData(GameData data)
    {
        this.Quest1Complete = data.Quest1;
        this.Quest2Complete = data.Quest2;
        this.Quest3Complete = data.Quest3;
        this.Quest4Complete = data.Quest4;
        this.Quest5Complete = data.Quest5;
        this.KeepSakeQuest= data.KeepSakeQuest;
        this.EscortQuest = data.EscortQuest;
    }

    public void SaveData(GameData data)
    {
        data.Quest1 = this.Quest1Complete;
        data.Quest2 = this.Quest2Complete;
        data.Quest3 = this.Quest3Complete;
        data.Quest4 = this.Quest4Complete;
        data.Quest5 = this.Quest5Complete;
        data.KeepSakeQuest= this.KeepSakeQuest;
        data.EscortQuest= this.EscortQuest;
    }

    // Update is called once per frame
    void Update()
    {
        QuestUpdate();
    }

     public void QuestUpdate()
    {
        if (BossDead)
        {
            SceneManager.LoadScene("Lv1 outro");
        }

        if(KeepSakeQuest == true)
        {
            KSSideQuest1Text.SetActive(false);
            KSCompleteQuest1Text.SetActive(true);
            KSQuestionMarks.SetActive(false);
        }

        if(EscortQuest == true)
        {
            EscortSideQuest1Text.SetActive(false);
            EscortCompleteQuest1Text.SetActive(true);
            EscortQuestionMarks.SetActive (false);
            EscortedNpc.SetActive(true);
            StartNpc.SetActive(false);


        }

        if(Quest1Complete == true)
        {

          //Q1ClosedGate.SetActive(false);
          //Q1OpenGate.SetActive(true);

            Q1SideQuest1Text.SetActive(false);
            Q1CompleteQuest1Text.SetActive(true);
            Q1QuestionMarks.SetActive(false);
            BrokenFence.SetActive(false);
        }

        if(Quest2Complete== true)
        {
            Q2ClosedGate.SetActive(false);
            Q2OpenGate.SetActive(true);

            Q2SideQuest1Text.SetActive(false);
            Q2CompleteQuest1Text.SetActive(true);
            Q2QuestionMarks.SetActive(false);
            //Q2KeyObject.SetActive(false);
        }

        if(Quest3Complete == true)
        {
            Q3ClosedGate.SetActive(false);
            Q3OpenGate.SetActive(true);

            Q3SideQuest1Text.SetActive(false);
            Q3CompleteQuest1Text.SetActive(true);
            Q3QuestionMarks.SetActive(false);
            Q3KeyObject.SetActive(false);

        }

        if (Quest4Complete)
        {

            Q4Door.SetActive(false);

            Q4SideQuest1Text.SetActive(false);
            Q4CompleteQuest1Text.SetActive(true);
            Q4QuestionMarks.SetActive(false);
            Q4KeyObject.SetActive(false);
        }

        if (Quest5_1Complete == true)
        {
            Q5Door.SetActive(false);
        }

        if (Quest5Complete)
        {

             
             Q5Door2.SetActive(false);

            Q5SideQuest1Text.SetActive(false);
            Q5CompleteQuest1Text.SetActive(true);
            Q5QuestionMarks.SetActive(false);
            //Q5KeyObject.SetActive(false);
        }
    }

}
