using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuesr1LV2 : MonoBehaviour
{

    public DiologeTrigger diologeTrigger;

    public GameObject IncompleteQuestText;
    public GameObject QuestionMarks;

    public GameObject HeadIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(diologeTrigger.DiologeStarted == true)
        {
            IncompleteQuestText.SetActive(true);
            QuestionMarks.SetActive(false);
            HeadIcon.SetActive(false);
        }
    }
}
