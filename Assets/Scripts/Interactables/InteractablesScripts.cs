using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class InteractablesScripts : MonoBehaviour
{
    public string objectName;
    public List<CatInteractionAction> events = new List<CatInteractionAction>();

    public void Start()
    {
        
    }

    public void DisplayInteractibleMenu(CatAttributes attributes)
    {
        var positionVector = InteractionMenuHandler.Instance.menuStartPosition;
        var canvas = InteractionMenuHandler.Instance.actionCanvas;
        for (int index = 0; index < events.Count; index++ )
        {
            var action = events[index];
            action.GenerateInteractionButton(canvas, InteractionMenuHandler.Instance.actionButtonPrefab, positionVector, attributes, index +1);
            positionVector.x += 50f;
        }
    }

    public void CloseInteractableMenu()
    {
        foreach (var action in events)
        {
            action.KillButton();
        }
    }

}

