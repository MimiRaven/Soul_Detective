using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CheckPoint : MonoBehaviour
{
    private C_PlayerHealth playerHealth;

    public Renderer theRend;

    public Material cpOff;
    public Material cpOn;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<C_PlayerHealth>();
    }

    public void CheckpointOn()
    {
        C_CheckPoint[] checkPoints = FindObjectsOfType<C_CheckPoint>();
        foreach (C_CheckPoint cp in checkPoints)
        {
            cp.CheckpointOff();
            //Destroy(gameObject);
        }

        theRend.material = cpOn;
        gameObject.tag = "CheckPointOn";
    }

    public void CheckpointOff()
    {
        gameObject.tag = "CheckPointOff";
        theRend.material = cpOff;
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("SpawnPointSets");
            playerHealth.SetSpawnPoint (transform.position);
            CheckpointOn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
