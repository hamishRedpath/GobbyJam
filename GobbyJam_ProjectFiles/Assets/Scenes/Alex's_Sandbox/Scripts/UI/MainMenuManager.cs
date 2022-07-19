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
    public GameObject QuitMenu;


    public void OpenMenu()
    {
        StartupMenu.SetActive(false);
        MainMenu.SetActive(true); ;
    }
    public void PlaySelected()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectPauseMenu()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
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
