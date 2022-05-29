using UnityEngine;

public class InteractablesScripts : MonoBehaviour
{
    public InteractiblesSO interactiblesSO;
    string objectName;

    void Start()
    {
        if (interactiblesSO != null)
            objectName = interactiblesSO.interactableName;
    }

    public string GetName()
    {
        if (interactiblesSO != null)
            return (interactiblesSO.interactableName);
        else
            return "";
    }



}
