using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemySliderScript : MonoBehaviour
{
    public Transform MainCam;

    public Transform AimCam;

    public C_SwitchAimCam c_SwitchAimCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(c_SwitchAimCam.AimOn == false)
        {
        transform.LookAt(MainCam);

        }

        if (c_SwitchAimCam.AimOn == true)
        {

            transform.LookAt(AimCam);
        }


    }
}
