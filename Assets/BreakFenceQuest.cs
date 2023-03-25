using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFenceQuest : MonoBehaviour
{
    public Level1SideQuestManager SideQuestManager;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Active")
        {
            SideQuestManager.Quest1Complete = true;

          // SideQuest1Text.SetActive(false);
          // CompleteQuest1Text.SetActive(true);
          // QuestionMarks.SetActive(false);

        }
    }
}
