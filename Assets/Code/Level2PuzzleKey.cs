using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Level2PuzzleKey : MonoBehaviour
{
    public Level2SideQuestManager SideQuestManager;
    public GameObject LootObject;
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
        if (other.gameObject.tag == "Key")
        {
            SideQuestManager.Quest4Complete = true;

            LootObject.SetActive(true);
          



          //  Destroy(other.gameObject);

        }
    }
}
