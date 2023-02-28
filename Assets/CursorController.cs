using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public SkilltreeManager skilltreeManager;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.isPaused == true || skilltreeManager.WheelIsOn == true)
        {
           Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        //else
        //{
        //    Cursor.visible = false;
        //}

       //if(skilltreeManager.WheelIsOn == true)
       //{
       //    Cursor.visible = true;
       //}
       //else
       //{
       //    Cursor.visible = false;
       //}
    }

    
}
