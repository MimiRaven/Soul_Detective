using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYardMusic : MonoBehaviour
{
    public AudioSource audioSource;
    private static GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        DontDestroyOnLoad(this.gameObject);
        if(player == null)
        {
            player = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
