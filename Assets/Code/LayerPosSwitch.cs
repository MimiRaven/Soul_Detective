using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerPosSwitch : MonoBehaviour
{
    public C_EnemyPossesed EnemyPossesed;
    public C_XrayVision Xray;

    public bool xRayActive;
    public bool PossesionActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PossesedSwitch();
        XraySwitch();

        if(EnemyPossesed.Possesed == true)
        {
            PossesionActive= true;
        }

        if (EnemyPossesed.Possesed == false && Xray.boosting == false)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Default");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("Default");  // add any layer you want. 
            }
        }
    }

    public void PossesedSwitch()
    {
        if (EnemyPossesed.Possesed == true)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Possesion");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("Possesion");  // add any layer you want. 
            }
        }
    }
    public void XraySwitch()
    {
        if (Xray.boosting == true)
        {
            xRayActive = true;
            this.gameObject.layer = LayerMask.NameToLayer("RenderAbove");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("RenderAbove");  // add any layer you want. 
            }


           
        }
    }
}
