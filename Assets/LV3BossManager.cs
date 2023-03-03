using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV3BossManager : MonoBehaviour
{
    public bool Boss1Dead;
    public bool Boss2Dead;
    public bool Boss3Dead;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss1Dead && Boss2Dead && Boss3Dead)
        {
            SceneManager.LoadScene("HubWorld");
        }
    }
}
