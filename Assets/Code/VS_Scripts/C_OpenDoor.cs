using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_OpenDoor : MonoBehaviour
{
    //public GameObject Door;
    public KeyInventory keyInventory;
    public C_EnemyPossesed c_EnemyPossesed;
    public C_PlayerController c_PlayerController;

    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {

            //Door.SetActive(false);
            keyInventory.KeyCount += 1;
            c_EnemyPossesed.Possesed = false;
            c_PlayerController.Possesed = true;
            audioSource.Play();
        }
    }
}
