using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class Lv2endtrigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LV2End")
        {
            SceneManager.LoadScene("Main Menu");



        }
    }

    void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("LV2End"))
        {
            SceneManager.LoadScene("Main Menu");

           
        }
    }
}
