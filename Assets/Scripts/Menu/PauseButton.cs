using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();

        if (pauseMenu == null)
        {
            Debug.LogError("Cannot find pause menu!");
        }
    }

    public void OnPauseButtonClicked()
    {
        if (pauseMenu != null)
        {
            pauseMenu.TogglePause();
        }
    }
}
