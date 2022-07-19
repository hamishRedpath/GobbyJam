using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    public GameObject buttonPrompt;
    public Transform cameraTrans;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            buttonPrompt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            buttonPrompt.SetActive(false);
    }

    public void Update()
    {
        buttonPrompt.transform.LookAt(cameraTrans);
    }
}
