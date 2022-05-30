using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemStack", order = 2)]

public class DropableItem : ScriptableObject
{
    public GameObject objectPrefab;
    public int numberOfStacks;

    public int CurrentStacks { get; set; }

    public void Awake()
    {
        CurrentStacks = numberOfStacks;
    }

    public GameObject DropItem(Transform source)
    {
        CurrentStacks--;
        return Instantiate(objectPrefab, source.position, source.rotation);
    }
}
