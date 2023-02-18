using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DetroyObjectWithTeleButton : MonoBehaviour
{
    public GameObject HazardObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {


        if (col.collider.tag == "NotActive")
        {
            HazardObject.SetActive(false);
        }
    }
 }
