using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenuHandler : MonoBehaviour
{
    public static InteractionMenuHandler Instance;

    public Canvas actionCanvas;
    public GameObject actionButtonPrefab; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
