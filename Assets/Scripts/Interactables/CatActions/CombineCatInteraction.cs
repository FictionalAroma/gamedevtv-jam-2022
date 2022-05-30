using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Global;
using UnityEngine;

namespace Assets.Scripts.Interactables.CatActions
{
    public class CombineCatInteraction : CatInteractionAction
    {
        public PickupableItem floorItem;
        private PickupableItem resultingItem;

        private void Awake()
        {
            floorItem = GetComponent<PickupableItem>();
        }

        public override void ActionSelected(CatAction action, CatAttributes attributes)
        {
            var catDrop = attributes.GetComponent<CatPickup>();
            if (catDrop != null)
            {
                var item = GameObject.Instantiate(resultingItem, catDrop.ObjectDropPoint.position, Quaternion.identity, LevelLookup.Instance.transform);
                if (attributes.HasSpaceInBagPostCrafting(item))
                {
                    attributes.PutInBagPostCrafting(item);
                }
                else
                {
                    item.DropItem(LevelLookup.Instance.transform, catDrop.ObjectDropPoint.position);
                       
                }

            }


        }

        public override bool IsActionValid(CatAttributes attributes)
        {
            var catDrop = attributes.GetComponent<CatPickup>();
            if (catDrop != null)
            {
                if (catDrop.pickedUpItem == null)
                {
                    return false;
                }

                if (floorItem == null)
                {
                    return false;
                }

                resultingItem = RecipeBook.Instance.GetRecipeItem(floorItem.itemName,catDrop.pickedUpItem.itemName);
            }

            return resultingItem != null;

        }


        private static readonly Func<DropableItem, bool> ValidItemCheck = item => item.CurrentStacks > 0;

    }
}