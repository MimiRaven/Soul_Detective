using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CheckPoint : MonoBehaviour
{
    private C_PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<C_PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerHealth.SetSpawnPoint (transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
