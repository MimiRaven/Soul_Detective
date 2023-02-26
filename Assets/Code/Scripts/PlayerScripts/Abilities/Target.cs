using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Target : MonoBehaviour
{
    private Rigidbody objectRb;
    public Transform objectGrabPointTransform;

    //AudioSource audioSource;
    //public AudioClip selectTelekinesis;

    public float pushForce = 0;
    float lerpSpeed = 10f;

    public bool Dropped;

   // public ParticleSystem telekinesis;
    public VisualEffect TeleVfxEffect;


    //void FixedUpdate()
    //{
    //    if (Dropped == true)
    //    {
    //        this.objectGrabPointTransform = null;
    //        objectRb.drag = 0;
    //        objectRb.useGravity = true;
    //        Debug.Log("Object Dropped");
    //        
    //
    //    }
    //   
    //}

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();

       // audioSource = GetComponent<AudioSource>();

    }

    public void Start()
    {
       // telekinesis.Stop();
        TeleVfxEffect.Stop();
    }

    public void Pull(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        //this.transform.parent = null;
        
    }

    public void Push(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        //this.transform.parent = null;

    }

    public void Grab(Transform objectGrabPointTransform)
    {
        //PlaySound(selectTelekinesis);
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRb.useGravity = false;
        objectRb.drag = 5;
        Debug.Log("Object Grabbed");
        Dropped = false;
        //telekinesis.Play();
        TeleVfxEffect.Play();
    }

   //public void Drop(Transform objectGrabPointTransform)
   //{
   //    objectRb.drag = 0;
   //    objectRb.useGravity = true;
   //    Debug.Log("Object Dropped");
   //    Dropped = true;
   //   
   //}

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            objectRb.MovePosition(objectGrabPointTransform.position);
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRb.MovePosition(newPosition);
        }

        if (Dropped == true)
        {
            this.objectGrabPointTransform = null;
            objectRb.drag = 0;
            objectRb.useGravity = true;
            Debug.Log("Object Dropped");
            //  telekinesis.Stop();
            TeleVfxEffect.Stop();

        }
    }

   //void PlaySound(AudioClip clip)
   //{
   //    audioSource.PlayOneShot(clip);
   //}
}