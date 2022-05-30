using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;

    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        paused = true;
        canvas.enabled = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        paused = false;
        canvas.enabled = false;
        Time.timeScale = 1;

    }
}
