using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    //private Rigidbody body;
    public bool disablePhysics = true;
    private Transform actualPosition;
    public bool doBounce = true;
    private bool isPickedUp = false;

    public string itemName;

    public float rotationSpeed = 20f;
    public float bounceSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<Rigidbody>();
        //body.isKinematic = disablePhysics;

        actualPosition = transform;
    }

    private float rotationTimer = 0f;
    private static Quaternion startRotation = new Quaternion(0, 0, 0, 0);
    private static Quaternion endRotation = new Quaternion(0, 360, 0, 0);
    private bool goUp = true;

    private float bouncyTimer = 0f;
    public void Update()
    {
        if (!isPickedUp && doBounce)
        {
            //rotationTimer += Time.deltaTime;
            //bouncyTimer += Time.deltaTime;
            //float rotationOffset = Mathf.Lerp(0f, 360f, bouncyTimer / bounceSpeed);

            //this.transform.rotation = new Quaternion(actualPosition.rotation.x, actualPosition.rotation.y + rotationOffset, actualPosition.rotation.z, actualPosition.rotation.w);

            //if (rotationTimer > rotationSpeed)
            //{
            //    rotationTimer = 0;
            //}

            if (goUp)
            {
                float bouncePositionOffset = Mathf.Lerp(0f, 0.01f, bouncyTimer/ bounceSpeed);
                this.transform.position = actualPosition.position + new Vector3(0, bouncePositionOffset, 0);
            }
            else
            {
                float bouncePositionOffset = Mathf.Lerp(0.01f, 0f,  bouncyTimer/ bounceSpeed);
                this.transform.position = actualPosition.position - new Vector3(0, bouncePositionOffset, 0);
            }

            if (bouncyTimer > bounceSpeed)
            {
                goUp = !goUp;
                bouncyTimer = 0;
            }

        }
    }

    public void Pickup(Transform newParent, Vector3 position)
    {
        transform.SetParent(newParent, false);;
        transform.position = position;

        //body.isKinematic = true;
        
        foreach (var component in GetComponents<Collider>())
        {
            component.enabled = false;
        }

        rotationTimer = 0f;
        bouncyTimer = 0f;
    }
    public void DropItem(Transform newParent, Vector3 position)
    {
        transform.SetParent(newParent, false); ;
        transform.position = position;

        //body.isKinematic = false;

        foreach (var component in GetComponents<Collider>())
        {
            component.enabled = true;
        }

    }

}
