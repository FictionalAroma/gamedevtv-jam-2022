using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;


public class EatCatInteraction : CatInteractionAction
{
    public float maxFoodValue;
    public float startingFoodValue;

    private float currentFoodValue;

    public bool isContainer;
    public bool destroyOnEmpty;

    public void Awake()
    {
        currentFoodValue = startingFoodValue;
    }

    public override void ActionSelected(CatAction action, CatAttributes attributes)
    {
        switch (action)
        {
            case CatAction.Eat:
            {
                currentFoodValue = attributes.EatFood(currentFoodValue);
                if (currentFoodValue < float.Epsilon && destroyOnEmpty)
                {
                    Destroy(this);
                }

                UpdateSprite(currentFoodValue);
                break;
            }
        }
    }

    private void UpdateSprite(float f)
    {
        
    }
}
