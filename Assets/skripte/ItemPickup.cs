using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        Pickup();
    }
    void Pickup()
    {
        if (Inventory.Instance.AddItem(item))
        {
            Debug.Log("Picking up " + item.name);
            Destroy(gameObject);
        }
    }
}
