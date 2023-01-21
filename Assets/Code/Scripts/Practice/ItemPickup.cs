using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
     public Item item;

   void Pickup()
   {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
   }

   private void OnTriggerEnter(Collider col)
   {
        PracticePlayer player =  col.gameObject.GetComponent<PracticePlayer>();
        if(player != null)
        {
            Pickup();
        }
   }
}