using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameClick()
    {
        LevelLoader.GoToMainGame();
    }

    public void ExitGame()
    {
        LevelLoader.ExitGame();
    }
}
