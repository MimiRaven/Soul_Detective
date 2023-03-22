using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Opendoorwithbutton : MonoBehaviour
{
    public GameObject ClosedDoor;
    public GameObject OpenDoor;

    void OnCollisionEnter(Collision col)
    {


        if (col.collider.tag == "NotActive")
        {
            ClosedDoor.SetActive(false);
            OpenDoor.SetActive(true);
        }

    }
}
