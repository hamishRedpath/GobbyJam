using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
        [SerializeField] private AudioMixer audioMixer;

        public void SetMaster(float sliderValue)
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        }

        public void SetMusic(float sliderValue)
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        }

        public void SetSFX(float sliderValue)
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        }
}
