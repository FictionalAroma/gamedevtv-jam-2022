using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppydowny : MonoBehaviour
{
    public AnimationCurve myCurve;
   
    void Update()
    {
        transform.position = new Vector3(transform.position.x, (-2+myCurve.Evaluate((Time.time % myCurve.length))), transform.position.z);
    }
}


