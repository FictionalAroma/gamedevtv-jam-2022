using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Global;
using UnityEngine;

namespace Assets.Scripts.Interactables.CatActions
{
    public class CombineCatInteraction : CatInteractionAction
    {
        public List<DropableItem> resultingItem;

        public bool destroyOnEmpty;

        public Transform spawnPoint;

        private readonly List<DropableItem> _runTimeItems = new();

        private void Awake()
        {
            resultingItem.ForEach(item => _runTimeItems.Add(UnityEngine.Object.Instantiate(item)));
        }

        public override void ActionSelected(CatAction action, CatAttributes attributes)
        {
            if (AreAnyItemsLeft)
            {
                var itemsToDrop = GetItemsWithStacks.ToArray();
                int itemIndex = 0;
                if (itemsToDrop.Count() > 1)
                {
                    itemIndex = UnityEngine.Random.Range(0, itemsToDrop.Count() - 1);
                }

                var item = itemsToDrop[itemIndex];
                if (attributes.HasSpaceInBag(item))
                {
                    attributes.PutInBag(item);
                }
                else
                {
                    var createdItem = item.DropItem(LevelLookup.Instance.transform, spawnPoint.position);
                }

                if (destroyOnEmpty && !AreAnyItemsLeft)
                {
                    Destroy(gameObject);
                }
            }
        }

        private bool AreAnyItemsLeft => _runTimeItems.Any(ValidItemCheck);
        private IEnumerable<DropableItem> GetItemsWithStacks => _runTimeItems.Where(ValidItemCheck);


        private static readonly Func<DropableItem, bool> ValidItemCheck = item => item.CurrentStacks > 0;

    }
}