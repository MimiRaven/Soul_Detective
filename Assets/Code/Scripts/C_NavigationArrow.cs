using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_NavigationArrow : MonoBehaviour
{
    public Transform target;

    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Objective").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
