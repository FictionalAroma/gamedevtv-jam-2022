using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatPickup : MonoBehaviour
{
    private PickupableItem lastTriggeredItem;

    private PickupableItem pickedUpItem;

    public Transform ObjectDropPoint;
    public Transform ObjectCarryPoint;

    public void OnPickup(InputValue input)
    {
        if (pickedUpItem != null)
        {
            pickedUpItem.DropItem(transform.parent, gameObject.transform.position + Vector3.up);
            pickedUpItem = null;
        }
        else
        {
            if (lastTriggeredItem != null)
            {
                lastTriggeredItem.Pickup(this.gameObject.transform, ObjectCarryPoint.position);
                pickedUpItem = lastTriggeredItem;
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        var pickupComponent = other.GetComponent<PickupableItem>();
        if (pickupComponent != null)
        {
            lastTriggeredItem = pickupComponent;
        }
    }
}
