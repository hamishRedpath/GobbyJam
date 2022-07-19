using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public GameObject ControlsMenu;
    public GameObject ExitMenu;

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }
    public void SelectOptions()
    {
        OptionsMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }

    public void SelectControls()
    {
        ControlsMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void SelectQuitScreen()
    {
        ControlsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        ExitMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DontQuitGame()
    {
        ExitMenu.SetActive(false);
    }
}
