using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject ControlsMenu;
    public GameObject ExitMenu;

    public void SelectOptions()
    {
        OptionsMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}
