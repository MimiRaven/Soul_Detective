using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_HoldPositionMover : MonoBehaviour
{
    //public Rigidbody objectRb;

    public bool ObjectPulled;
    public bool ObjectPushed;

    public float moveSpeed = 10f;

    //public GameObject StartHoldpos;
    //[SerializeField]
    //private Transform _target;

    //playerCombat = FindObjectOfType<CombatScript>();

    //public Transform target;

    //public GameObject StartHoldpos;

    public GameObject Player;

    public GameObject parentObj;
    public GameObject childObj;

    


    void Start()
    {

        Player = GameObject.Find("Player/ThirdPersonPlayer");



        //playerCombat = FindObjectOfType< "Move Hold Position" >();
    }


    private void Awake()
    {
        // objectRb = GetComponent<Rigidbody>();

        
        //_target = StartHoldpos.transform;
    }

    void Update()
    {
        Pull();
        Push();

        childObj.transform.parent = parentObj.transform;

        //transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));

    }

    public void Pull()
    {
        if(ObjectPulled == true)
        {
            //transform.LookAt(new Vector3(playerCombat.transform.position.x, transform.position.y, playerCombat.transform.position.z));

            Debug.Log("Object Pulled");

            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

            
            this.transform.parent = null;

        }

    }

    public void Push()
    {
        if (ObjectPushed == true)
        {
            
            Debug.Log("Object Pulled");
            //objectRb.velocity = new Vector3(0, 0, 5);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            this.transform.parent = null;

        }

    }
}
