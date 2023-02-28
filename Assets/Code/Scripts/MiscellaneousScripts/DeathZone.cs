using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public C_PlayerHealth C_PlayerHealth;
    void OnTriggerEnter(Collider other)
    {
       // C_PlayerController player = other.gameObject.GetComponent<C_PlayerController>();

        if (other.CompareTag("Player"))
        {
            C_PlayerHealth.Respwan();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
