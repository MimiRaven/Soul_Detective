using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathManager : MonoBehaviour
{
    public bool Boss1Dead;
    public bool Boss2Dead;
    public GameObject HellDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss1Dead && Boss2Dead == true)
        {
            HellDoor.SetActive(false);
        }
    }
}
