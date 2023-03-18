using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLv1Completion : MonoBehaviour
{

    public LevelCompletionManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Lv1Complete")
        {
            levelManager.Lv1Complete = true;
            SceneManager.LoadScene("HubWorld");

        }
    }


    
}
