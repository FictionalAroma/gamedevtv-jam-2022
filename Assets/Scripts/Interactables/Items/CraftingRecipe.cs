using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CraftingRecipe", order = 2)]

public class CraftingRecipe : ScriptableObject
{
    public string key1;
    public string key2;
    public PickupableItem itemResult;
    public UnityAction alternativeAction;

    public bool Match(string find1, string find2)
    {
        return (string.Compare(key1, find1, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(key2, find2, StringComparison.InvariantCultureIgnoreCase) == 0) ||
               (string.Compare(key1, find2, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(key2, find1, StringComparison.InvariantCultureIgnoreCase) == 0)
            ;
    }
}
