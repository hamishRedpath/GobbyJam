using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public  Text textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
    }

    public void ShowSliderValue(float value)
    {
        textSliderValue.text = Mathf.RoundToInt(value) + "%";
    }
}