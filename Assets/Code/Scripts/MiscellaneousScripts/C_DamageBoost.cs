using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_DamageBoost : MonoBehaviour
{
    private float boostTimer;
    private bool boosting;

    public GameObject PlayerWeapon;

    public GameObject LockOnCanvas;
    public TextMeshProUGUI BoostedUI;
    // Start is called before the first frame update
    void Start()
    {
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (boosting)
        {
            LockOnCanvas.SetActive(true);
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                PlayerWeapon.tag = "weapon";
                boostTimer = 0;
                boosting = false;
                BoostedUI.text = "Weapon Boosted";
            }
        }
        else
        {
            LockOnCanvas.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        
          if (collision.gameObject.tag == "DamageBoostPickUp")
          {
            PlayerWeapon.tag = "BoostedWeapon";
            Destroy(collision.gameObject);
            boosting = true;
        }

           
        
    }
}