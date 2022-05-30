using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public abstract class CatInteractionAction : MonoBehaviour
{
    public CatAction catAction;
    public InteractionType interactionTarget;
    public Sprite buttonImage;
    private CatAttributes cachedAttributes;
    private GameObject actionButton;
    public string ActionTextOverride;

    public virtual void GenerateInteractionButton(Canvas drawCanvas, GameObject buttonPrefab,Vector2 position, CatAttributes attributes,
        int index)
    {
        actionButton = Instantiate(buttonPrefab, drawCanvas.transform);
        actionButton.transform.localPosition = position;
        var actionButtonWrapper = actionButton.GetComponent<ActionButtonWrapper>();
        var spriteRender = actionButtonWrapper.spriteRenderer;
        if (spriteRender != null)
        {
            spriteRender.sprite = buttonImage;
        }

        cachedAttributes = attributes;
        var button = actionButtonWrapper.buttonComponent;
        if (button != null)
        {
            button.enabled = IsActionValid(attributes);
            button.onClick.AddListener(ButtonClick);
        }

        var textUI = actionButtonWrapper.actionNumberText;
        if (textUI != null)
        {
            textUI.text = $"{index} - {(string.IsNullOrWhiteSpace(ActionTextOverride) ? catAction.ToString() : ActionTextOverride)}";
        }
    }

    public void ButtonClick()
    {
        ActionSelected(catAction, cachedAttributes);
    }

    public virtual bool IsActionValid(CatAttributes attributes)
    {
        return true;
        // ReSharper disable once ConvertIfStatementToReturnStatement
        // this could be written with one line, but to be honest this is clearer
        switch (interactionTarget)
        {
            case InteractionType.HeldObject:
            {
                return attributes.HeldObject != null;
            }
            default:
            {
                return true;
            }
        }
    }

    public abstract void ActionSelected(CatAction action, CatAttributes attributes);

    public void KillButton()
    {
        Destroy(actionButton);
    }
}

public delegate void ActionConfirmed(CatAction catAction, CatAttributes attributes);

public enum CatAction
{
    Bab,
    Eat,
    Pickup,
    Climb,
    Ruin,
    Transfer,
}
public enum InteractionType
{
    Cat,
    HeldObject
}
