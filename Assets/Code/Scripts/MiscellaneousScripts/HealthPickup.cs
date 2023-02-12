using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        C_PlayerHealth controller = other.GetComponent<C_PlayerHealth>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(3);
                Destroy(gameObject);
                Debug.Log("HealthPickedUp");
            }
        }
    }

    public void Update()
    {
        transform.Rotate(0f, 80f * Time.deltaTime, 0f, Space.Self);
    }
}
