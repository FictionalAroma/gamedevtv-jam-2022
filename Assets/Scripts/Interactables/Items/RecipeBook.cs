using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{


    public List<CraftingRecipe> RecipeList;
    public PickupableItem GetRecipeItem(string object1, string object2)
    {
        string lookup = $"{object1}|{object2}";

        return RecipeList.FirstOrDefault(s => s.Match(object1, object2)).itemResult;
    }
}

