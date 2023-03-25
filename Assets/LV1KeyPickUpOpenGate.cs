using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1KeyPickUpOpenGate : MonoBehaviour
{
   //public GameObject SideQuest1Text;
   //public GameObject CompleteQuest1Text;
   //
   //public GameObject QuestionMarks;
   //
   //public GameObject ClosedGate;
   //public GameObject OpenGate;

    public GameObject PuzzleEnemy;

    public C_EnemyPossesed C_EnemyPossesed;
    // public Bot Bot;
    public C_PlayerController C_PlayerController;
    public C_PossesedEnemyAttack C_PossesedEnemyAttack;

    public Level1SideQuestManager QuestManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  //void OnCollisionEnter(Collision collision)
  //{
  //    if (collision.gameObject.tag == "Key")
  //    {
  //        C_PlayerController.Possesed = true;
  //        C_EnemyPossesed.Possesed = false;
  //        PuzzleEnemy.SetActive(false);
  //
  //        ClosedGate.SetActive(false);
  //        OpenGate.SetActive(true);
  //
  //        SideQuest1Text.SetActive(false);
  //        CompleteQuest1Text.SetActive(true);
  //        QuestionMarks.SetActive(false);
  //
  //        Destroy(gameObject); 
  //
  //    }
  //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {

            QuestManager.Quest3Complete = true;

            C_PlayerController.Possesed = true;
            C_EnemyPossesed.Possesed = false;
            PuzzleEnemy.SetActive(false);

          //ClosedGate.SetActive(false);
          //OpenGate.SetActive(true);
          //
          //SideQuest1Text.SetActive(false);
          //CompleteQuest1Text.SetActive(true);
          //QuestionMarks.SetActive(false);

            Destroy(gameObject);

        }
    }
}
