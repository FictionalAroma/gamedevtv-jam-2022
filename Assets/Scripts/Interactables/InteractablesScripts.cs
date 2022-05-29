using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEditor.SceneManagement;
using UnityEngine;

public class InteractablesScripts : MonoBehaviour
{
    public string objectName;
    public Vector3 menuPositionOffest;
    public List<CatInteractionAction> events = new List<CatInteractionAction>();

    private Canvas newCanvas;
    public void Start()
    {
        
    }

    public void DisplayInteractibleMenu(CatAttributes attributes)
    {
        var positionVector = new Vector2(-500, 100);
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

    public void OnClickTest()
    {
        Debug.Log("ClickerWorked");
    }

}

