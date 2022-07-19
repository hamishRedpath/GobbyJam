using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public GameObject ControlsMenu;
    public GameObject ExitMenu;

    public GameObject resumeFade;
    public GameObject One;
    public GameObject Two;
    public GameObject Three;
        

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        resumeFade.SetActive(true);
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        Three.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Three.gameObject.SetActive(false);
        Two.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Two.gameObject.SetActive(false);
        One.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        One.gameObject.SetActive(false);
        resumeFade.gameObject.SetActive(false);
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
        SceneManager.LoadScene(0);
    }

    public void DontQuitGame()
    {
        ExitMenu.SetActive(false);
    }

}
