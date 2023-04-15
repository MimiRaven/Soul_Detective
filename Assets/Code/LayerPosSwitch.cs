using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerPosSwitch : MonoBehaviour
{
    public C_EnemyPossesed EnemyPossesed;
   // public LayerSwitch LayerSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyPossesed.Possesed == true )
        {
            this.gameObject.layer = LayerMask.NameToLayer("Possesion");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("Possesion");  // add any layer you want. 
            }
        }
        else
        {
            this.gameObject.layer = LayerMask.NameToLayer("Default");

            foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("Default");  // add any layer you want. 
            }
        }
    }
}
