using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        C_PlayerHealth controller = other.GetComponent<C_PlayerHealth>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                Debug.Log("HealthPickedUp");
            }
        }
    }
}
