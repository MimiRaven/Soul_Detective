using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial_Text : MonoBehaviour
{
    public GameObject UITextObject;
    // Start is called before the first frame update
    void Start()
    {
        UITextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UITextObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(UITextObject);
        Destroy(gameObject);
    }
}
