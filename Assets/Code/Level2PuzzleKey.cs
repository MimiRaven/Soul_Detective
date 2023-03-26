using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Level2PuzzleKey : MonoBehaviour
{
    public Level2SideQuestManager SideQuestManager;
    public GameObject XPObject1;
    public GameObject XPObject2;
    public GameObject XPObject3;
    public GameObject XPObject4;
    public GameObject XPObject5;
    public GameObject XPObject6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            SideQuestManager.Quest4Complete = true;

            XPObject1.SetActive(true);
            XPObject2.SetActive(true);
            XPObject3.SetActive(true);
            XPObject4.SetActive(true);
            XPObject5.SetActive(true);
            XPObject6.SetActive(true);



          //  Destroy(other.gameObject);

        }
    }
}
