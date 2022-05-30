using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Interactables.CatActions
{
    public class ClawCatInteraction : CatInteractionAction
    {
        public List<DropableItem> resultingItem;

        public bool destroyOnEmpty;

        private readonly List<DropableItem> runTimeItems = new List<DropableItem>();

        private void Awake()
        {
            resultingItem.ForEach(item => runTimeItems.Add(UnityEngine.Object.Instantiate(item)));
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
                    var createdItem = item.DropItem(this.transform);
                }

                if (destroyOnEmpty && !AreAnyItemsLeft)
                {
                    Destroy(gameObject);
                }
            }
        }

        private bool AreAnyItemsLeft => runTimeItems.Any(ValidItemCheck);
        private IEnumerable<DropableItem> GetItemsWithStacks => runTimeItems.Where(ValidItemCheck);


        private static readonly Func<DropableItem, bool> ValidItemCheck = item => item.CurrentStacks > 0;

    }
}