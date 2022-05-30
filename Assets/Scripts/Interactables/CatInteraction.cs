using System;
using System.Linq;
using System.Text;
using Assets.Scripts;
using Assets.Scripts.Global;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    private InteractablesScripts currentInteractablesObject;


    private void OnTriggerEnter(Collider other)
    {
        var thisCollider = GetComponent<CharacterController>();
        if (other.CompareTag(Tags.InteractablesTag))
        {
            var triggeredObject = other.GetComponent<InteractablesScripts>();
            if (triggeredObject != null)
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
        else if (other.CompareTag(Tags.PickupTag))
        {
            var test = thisCollider.
            test.
        }
    }

    private void OnTriggerExit(Collider other)
    {
       currentInteractablesObject.CloseInteractableMenu();
    }
}
