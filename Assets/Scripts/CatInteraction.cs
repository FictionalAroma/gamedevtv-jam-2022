using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{

    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(other);
    }

}
