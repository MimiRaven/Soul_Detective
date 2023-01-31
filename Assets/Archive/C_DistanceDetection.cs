using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DistanceDetection : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public float Distance_;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance_ = Vector3.Distance(player.transform.position, Enemy.transform.position);


    }
}
