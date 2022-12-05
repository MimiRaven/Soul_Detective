using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public float KeyCount;
    public GameObject Door;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(KeyCount == 2)
        {
            Door.SetActive(false);
            audioSource.Play();
        }

       
    }
}
