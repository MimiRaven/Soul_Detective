using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubWorldDoorManager : MonoBehaviour
{

    public LevelCompletionManager levelManager;

    public GameObject Level1DoorOpen;
    public GameObject Level2DoorOpen;
    public GameObject Level3DoorOpen;

    public GameObject Level1DoorClosed;
    public GameObject Level2DoorClosed;
    public GameObject Level3DoorClosed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.Lv1Complete == true)
        {

            //Level1DoorOpen.tag = ("Untagged");
            Level1DoorOpen.SetActive(false);
            Level1DoorClosed.SetActive(true);
        }

        if(levelManager.Lv2Complete == true)
        {

            Level2DoorOpen.SetActive(false);
            Level2DoorClosed.SetActive(true);
        }

        if(Level3DoorOpen == true)
        {
            Level3DoorOpen.SetActive(false);
            Level3DoorClosed.SetActive(true);
        }
    }
}
