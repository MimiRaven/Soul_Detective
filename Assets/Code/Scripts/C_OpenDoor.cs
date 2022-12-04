using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_OpenDoor : MonoBehaviour
{
    public GameObject Door;
    public C_EnemyPossesed c_EnemyPossesed;
    public C_PlayerController c_PlayerController;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {

            Door.SetActive(false);
            c_EnemyPossesed.Possesed = false;
            c_PlayerController.Possesed = true;
        }
    }
}
