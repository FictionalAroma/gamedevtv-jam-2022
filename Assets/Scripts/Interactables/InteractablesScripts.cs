using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesScripts : MonoBehaviour
{
    public InteractiblesSO interactiblesSO;
    string objectName;

    void Start()
    {
        objectName = interactiblesSO.interactableName;
    }

    public string GetName()
    {
        return(interactiblesSO.interactableName);
    }

    

}
