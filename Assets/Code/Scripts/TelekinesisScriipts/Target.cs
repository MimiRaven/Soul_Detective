using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody objectRb;
    public Transform objectGrabPointTransform;

    public float pushForce = 0;
    float lerpSpeed = 10f;

    public bool Dropped;


    void Update()
    {
        if (Dropped == true)
        {
            this.objectGrabPointTransform = null;
            objectRb.drag = 0;
            objectRb.useGravity = true;
            Debug.Log("Object Dropped");
            

        }
       
    }

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();



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
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRb.useGravity = false;
        objectRb.drag = 5;
        Debug.Log("Object Grabbed");
        Dropped = false;
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
    }




}
