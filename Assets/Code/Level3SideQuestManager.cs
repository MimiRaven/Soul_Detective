using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3SideQuestManager : MonoBehaviour, IDataPersistence
{
    public bool Quest1Complete;
    public bool Quest2Complete;
    public bool Quest3Complete;
    public bool Quest4Complete;

    public bool Level3Complete;

    
    // public bool Quest5Complete;
    // public bool Quest5_1Complete;
    [Header("Main Quest 1 Variables")]
    public bool Boss1Dead;
    public bool Boss2Dead;
    public bool Boss3Dead;

    public bool AllMiniBossesDead;
    public GameObject AllBossAliveText;
    public GameObject AllBossDeadText;

    public bool FinalBossDead;

    //public GameObject BossDoor;
    public GameObject BossDoorTransportObject;

    public GameObject Boss1AliveText;
    public GameObject Boss2AliveText;
    public GameObject Boss3AliveText;
    public GameObject Boss4AliveText;
    public GameObject Boss1DeadText;
    public GameObject Boss2DeadText;
    public GameObject Boss3DeadText;
    public GameObject Boss4DeadText;

    [Header("Main Quest 1 Variables")]
    public bool FetchQuest;
    public GameObject FQSideQuest1Text;
    public GameObject FQCompleteQuest1Text;
    public GameObject FQQuestionMarks;


    //[Header("Quest 1 Variables")]
    ////public GameObject Q1ClosedGate;
    //public GameObject Debris;
    //public GameObject Q1SideQuest1Text;
    //public GameObject Q1CompleteQuest1Text;
    //public GameObject Q1QuestionMarks;
    //
    //[Header("Quest 2 Variables")]
    //public GameObject Q2ClosedGate;
    //public GameObject Q2OpenGate;
    //public GameObject Q2SideQuest1Text;
    //public GameObject Q2CompleteQuest1Text;
    //public GameObject Q2QuestionMarks;
    ////public GameObject Q2KeyObject;
    //
    //[Header("Quest 3 Variables")]
    //public GameObject Q3ClosedGate;
    //public GameObject Q3OpenGate;
    //public GameObject Q3SideQuest1Text;
    //
    //public GameObject Q3CompleteQuest1Text;
    //public GameObject Q3QuestionMarks;
    //public GameObject Hazard;
    //
    //[Header("Quest 4 Variables")]
    //// public GameObject Q4Door;
    //public GameObject Q4SideQuest1Text;
    //public GameObject Q4CompleteQuest1Text;
    //public GameObject Q4QuestionMarks;
    //public GameObject Q4KeyObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        QuestUpdate();
    }

    public void LoadData(GameData data)
    {
       this.Boss1Dead = data.FirstBossDead;
        this.Boss2Dead = data.SecondBossDead;
        this.Boss3Dead= data.ThirdBossDead;
        this.AllMiniBossesDead = data.MiniBossesDead;
        this.FinalBossDead= data.FinalBossDead;
        this.Level3Complete = data.Level3Complete;

       //this.LeftBossDead = data.LeftBossDead;
       //this.Quest1Complete = data.LV2Quest1;
       //this.Quest2Complete = data.LV2Quest2;
       //this.Quest3Complete = data.LV2Quest3;
       //this.Quest4Complete = data.LV2Quest4;
    }

    public void SaveData(GameData data)
    {
        data.FinalBossDead= this.Boss1Dead;
        data.SecondBossDead= this.Boss2Dead;
        data.ThirdBossDead= this.Boss3Dead;
        data.MiniBossesDead = this.AllMiniBossesDead;
        data.FinalBossDead= this.FinalBossDead;
        data.Level3Complete= this.Level3Complete;
       // data.RightBossDead = this.RightBossDead;
       // data.LeftBossDead = this.LeftBossDead;
       // data.LV2Quest1 = this.Quest1Complete;
       // data.LV2Quest2 = this.Quest2Complete;
       // data.LV2Quest3 = this.Quest3Complete;
       // data.LV2Quest4 = this.Quest4Complete;
    }

    public void QuestUpdate()
    {
       //if (RightBossDead)
       //{
       //    RightBossAliveText.SetActive(false);
       //    RightBossDeadText.SetActive(true);
       //}
       //if (LeftBossDead)
       //{
       //    LeftBossAliveText.SetActive(false);
       //    LeftBossDeadText.SetActive(true);
       //}

        if(FetchQuest == true)
        {
            FQSideQuest1Text.SetActive(false);
            FQCompleteQuest1Text.SetActive(true);
            FQQuestionMarks.SetActive(false);

        }

        if(Boss1Dead == true) 
        { 
          Boss1AliveText.SetActive(false);
            Boss1DeadText.SetActive(true);
        }
        if(Boss2Dead == true)
        {
            Boss2AliveText.SetActive(false);
            Boss2DeadText.SetActive(true);
        }
        if(Boss3Dead == true)
        {
            Boss3AliveText.SetActive(false);
            Boss3DeadText.SetActive(true);
        }

        if(AllMiniBossesDead== true)
        {
            AllBossAliveText.SetActive(false);
            AllBossDeadText.SetActive(true);

            BossDoorTransportObject.SetActive(true);
        }

        if(FinalBossDead== true)
        {
            Level3Complete = true;
            SceneManager.LoadScene("Lv3 outro");
        }

       //if (Quest1Complete == true)
       //{
       //
       //    //Q1ClosedGate.SetActive(false);
       //    //Q1OpenGate.SetActive(true);
       //
       //    Q1SideQuest1Text.SetActive(false);
       //    Q1CompleteQuest1Text.SetActive(true);
       //    Q1QuestionMarks.SetActive(false);
       //    Debris.SetActive(false);
       //}
       //
       //if (Quest2Complete == true)
       //{
       //    Q2ClosedGate.SetActive(false);
       //    Q2OpenGate.SetActive(true);
       //
       //    Q2SideQuest1Text.SetActive(false);
       //    Q2CompleteQuest1Text.SetActive(true);
       //    Q2QuestionMarks.SetActive(false);
       //    //Q2KeyObject.SetActive(false);
       //}
       //
       //if (Quest3Complete == true)
       //{
       //    Q3ClosedGate.SetActive(false);
       //    Q3OpenGate.SetActive(true);
       //
       //    Q3SideQuest1Text.SetActive(false);
       //    Q3CompleteQuest1Text.SetActive(true);
       //    Q3QuestionMarks.SetActive(false);
       //    Hazard.SetActive(false);
       //
       //}
       //
       //if (Quest4Complete)
       //{
       //
       //    //Q4Door.SetActive(false);
       //
       //    Q4KeyObject.SetActive(false);
       //
       //    Q4SideQuest1Text.SetActive(false);
       //    Q4CompleteQuest1Text.SetActive(true);
       //    Q4QuestionMarks.SetActive(false);
       //
       //}

    }
}
