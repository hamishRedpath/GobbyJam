using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject StartupMenu;
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject ControlsMenu;
    public GameObject QuitMenu;
    public GameObject mainTitle;

    


    public void OpenMenu()
    {
        StartupMenu.SetActive(false);
        MainMenu.SetActive(true);
        mainTitle.SetActive(true);
    }
    public void SelectPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectOptionsMenu()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void SelectControlsMenu()
    {
        ControlsMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void SelectQuitMenu()
    {
        QuitMenu.SetActive(true);
    }

    public void BackButton()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
        QuitMenu.SetActive(false);
        ControlsMenu.SetActive(false);
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        BackButton();
    }


}
