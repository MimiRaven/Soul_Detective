using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2SkyScraperPuzzle : MonoBehaviour
{
    public Diolouge diologe;

    public GameObject PlayerObject;
    public Transform Teleportpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if(diologe.TextEnded == true)
       //{
       //    PlayerObject.transform.position = Teleportpoint.transform.position;
       //}
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("LV2SkyTeleport"))
        {

            PlayerObject.transform.position = Teleportpoint.transform.position;

        }
    }
}
