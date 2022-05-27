using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Global;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    string triggeredName;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<InteractablesScripts>() != null)
        {
            triggeredName = other.GetComponent<InteractablesScripts>().GetName();
            Debug.Log(triggeredName);

            CatFadingTextController.Instance.StartCatTalk(triggeredName);
        }
    }
    

}
