using System.Text;
using Assets.Scripts.Global;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    string triggeredName;

    private void OnTriggerEnter(Collider other)
    {
        var triggeredObject = other.GetComponent<InteractablesScripts>();
        if (triggeredObject != null)
        {
            triggeredName = triggeredObject.GetName();
            Debug.Log(triggeredName);

            if (triggeredObject.interactiblesSO != null)
            {
                StringBuilder stringBuilder = new StringBuilder(triggeredName);
                triggeredObject.interactiblesSO.catActions.ForEach(action => stringBuilder.AppendLine(action.ToString()));
                CatFadingTextController.Instance.StartCatTalk(stringBuilder.ToString());
            }
        }
    }


}
