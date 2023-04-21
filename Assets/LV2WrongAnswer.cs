using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV2WrongAnswer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "weapon")
        {

            SceneManager.LoadScene("Lose Screen");

        }
    }
}
