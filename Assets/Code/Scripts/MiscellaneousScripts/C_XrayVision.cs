using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_XrayVision : MonoBehaviour
{
    private float boostTimer;
    public bool boosting;

    public GameObject LockOnCanvas;
    public TextMeshProUGUI BoostedUI;


    public GameObject XrayCam, AimXrayCam;

    public C_SwitchAimCam c_SwitchAimCam;

    // Start is called before the first frame update
    void Start()
    {
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (boosting)
        {
            //if(c_SwitchAimCam.AimOn == false)
            //{
            //    XrayCam.SetActive(true);
            //    AimXrayCam.SetActive(false);
            //}
            //else
            //{
            //    XrayCam.SetActive(false);
            //    AimXrayCam.SetActive(true);
            //}

            //LockOnCanvas.SetActive(true);
            //XrayCam.SetActive(true);
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {

                boostTimer = 0;
                boosting = false;
                BoostedUI.text = "XRay Active";
            }
        }
        //else
        //{
        //    LockOnCanvas.SetActive(false);
        //    XrayCam.SetActive(false);
        //    AimXrayCam.SetActive(false);
        //}

        //XrayCam.SetActive(true);
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "XRayBoostPickUp")
        {

            Destroy(collision.gameObject);
            boosting = true;
        }



    }

}
