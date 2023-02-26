using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1OpenGateWithButton : MonoBehaviour
{
    public GameObject ClosedGate;
    public GameObject OpenGate;

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
            ClosedGate.SetActive(false);
            OpenGate.SetActive(true);

            SideQuest1Text.SetActive(false);
            CompleteQuest1Text.SetActive(true);
            QuestionMarks.SetActive(false);
        }
    }
}
