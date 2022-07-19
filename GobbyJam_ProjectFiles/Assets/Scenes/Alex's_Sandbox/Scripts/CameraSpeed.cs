using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSpeed : MonoBehaviour
{
    public Slider camSlider;
    void Update()
    {
       PlayerController.camSpeed =  camSlider.value;

        Debug.Log(PlayerController.camSpeed);
    }
}
