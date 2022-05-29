using System;
using System.Text;
using Assets.Scripts;
using Assets.Scripts.Global;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    private InteractablesScripts currentInteractablesObject;


    private void OnTriggerEnter(Collider other)
    {
        var triggeredObject = other.GetComponent<InteractablesScripts>();
        if (triggeredObject != null )
        {
            currentInteractablesObject = triggeredObject;
            Debug.Log(triggeredObject.objectName);

            StringBuilder stringBuilder = new StringBuilder(triggeredObject.objectName);
            triggeredObject.events.ForEach(action => stringBuilder.AppendLine(action.catAction.ToString()));
            CatFadingTextController.Instance.StartCatTalk(stringBuilder.ToString());
            var attributes = GetComponent<CatAttributes>();
            triggeredObject.DisplayInteractibleMenu(attributes);
        }
    }

    private void OnTriggerExit(Collider other)
    {
       currentInteractablesObject.CloseInteractableMenu();
    }
}
