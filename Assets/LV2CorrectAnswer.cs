using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV2CorrectAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    public Lv2SkyScraperPuzzle SkyScraperPuzzle;

    public GameObject PlayerObject;
    public Transform Teleportpoint;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "weapon")
        {
            
            SkyScraperPuzzle.CorrectAnswerChosen= true;

            PlayerObject.transform.position = Teleportpoint.transform.position;

        }
    }
}
