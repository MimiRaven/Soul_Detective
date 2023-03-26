using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3BossAreaTeleport : MonoBehaviour
{
    public GameObject PlayerObject;
    public Transform Teleportpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("BossTeleport"))
        {

            PlayerObject.transform.position = Teleportpoint.transform.position;

        }
    }
}
