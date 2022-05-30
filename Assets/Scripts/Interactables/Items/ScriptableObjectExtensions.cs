using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public static class ScriptableObjectExtensions 
    {
        public static T CreateGameInstance<T>(this T toClone) where T : ScriptableObject
        {
            return Object.Instantiate(toClone);
        }

    }
}