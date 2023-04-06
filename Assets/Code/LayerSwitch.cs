using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitch : MonoBehaviour
{
    public C_XrayVision Xray;

    public LayerMask defaultLayer;
    public LayerMask XRaylayerMask;

    public bool xRayActive;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Xray.boosting == true)
        {
            xRayActive= true;
            this.gameObject.layer = LayerMask.NameToLayer("RenderAbove");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("RenderAbove");  // add any layer you want. 
            }


            // xRayActive = !xRayActive;
            //this.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
            //
            //int layerNum = (int)Mathf.Log(defaultLayer.value, 2);
            //gameObject.layer = layerNum;
            //
            //if(transform.childCount> 0 ) 
            //    SetLayerAllChilderen(transform, layerNum);
        }
        else
        {
            xRayActive = false;
            this.gameObject.layer = LayerMask.NameToLayer("Default");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("Default");  // add any layer you want. 
            }

        }
    }

   // void SetLayerAllChilderen(Transform root, int layer)
   // {
   //     var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
   //
   //     foreach (var child in children)
   //     {
   //         child.gameObject.layer = layer;
   //     }
   // }
   //
   // public static void ChangeLayersRecursively(this Transform trans, string name)
   // {
   //     trans.gameObject.layer = LayerMask.NameToLayer(name);
   //     foreach (Transform child in trans)
   //     {
   //         child.ChangeLayersRecursively(name);
   //     }
   // }




}
