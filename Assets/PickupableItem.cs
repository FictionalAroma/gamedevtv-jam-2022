using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Pickup(Transform newParent, Vector3 position)
    {
        transform.SetParent(newParent, false);;
        transform.localPosition = position;

        body.isKinematic = true;
        
        foreach (var component in GetComponents<Collider>())
        {
            component.enabled = false;
        }

    }
    public void DropItem(Transform newParent, Vector3 position)
    {
        transform.SetParent(newParent, false); ;
        transform.position = position;

        body.isKinematic = false;

        foreach (var component in GetComponents<Collider>())
        {
            component.enabled = true;
        }

    }

}
