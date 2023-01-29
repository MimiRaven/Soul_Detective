using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_EndGame : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {

            SceneManager.LoadScene("Main Menu");
        }
    }
}
