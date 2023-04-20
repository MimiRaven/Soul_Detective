using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2PuzzleDoorClosed : MonoBehaviour
{

    public GameObject PuzzleDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LV2PuzzleArea"))
        {
            PuzzleDoor.SetActive(true);
        }
    }
}
