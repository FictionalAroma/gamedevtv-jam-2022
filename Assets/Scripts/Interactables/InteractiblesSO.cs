using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InteractiblesSO", order = 1)]
public class InteractiblesSO : ScriptableObject
{
    public string interactableName;

    public List<CatAction> catActions;
}

public enum CatAction
{
    Bab,
    Eat,
    Pickup,
    Climb
}
