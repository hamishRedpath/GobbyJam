using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioCrossFade : MonoBehaviour
{
    public AudioMixer ostMix;

    private float currentSpringVol, currentForestVol, currentSwampVol, currentPoolVol;

    public float trackNumber;

    public void Update()
    {
        switch (trackNumber)
        {
            case 0:
                StopAllCoroutines();
                StartCoroutine(HotSpringFade());
                break;
            case 1:
                StopAllCoroutines();
                StartCoroutine(RockPoolFade());
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(SwampFade());
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(RainForestFade());
                break;
                default:
                StopAllCoroutines();
                break;
        }
    }
    #region Faders
    public IEnumerator HotSpringFade()
    {
        float currentTime = 0;
        ostMix.GetFloat("hotSpringVol", out currentSpringVol);
        ostMix.GetFloat("rainForestVol", out currentForestVol);
        ostMix.GetFloat("swampVol", out currentSwampVol);
        ostMix.GetFloat("rockPoolVol", out currentPoolVol);
        currentSpringVol = Mathf.Pow(10, currentSpringVol / 20);
        currentForestVol = Mathf.Pow(10, currentForestVol / 20);
        currentSwampVol = Mathf.Pow(10, currentSwampVol / 20);
        currentPoolVol = Mathf.Pow(10, currentPoolVol / 20);
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentSpringVol, 1, currentTime / 2);
            float newLow = Mathf.Lerp(currentForestVol, 0, currentTime / 2);
            ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("hotSpringVol", Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }

    public IEnumerator RockPoolFade()
    {
        float currentTime = 0;
        ostMix.GetFloat("hotSpringVol", out currentSpringVol);
        ostMix.GetFloat("rainForestVol", out currentForestVol);
        ostMix.GetFloat("swampVol", out currentSwampVol);
        ostMix.GetFloat("rockPoolVol", out currentPoolVol);
        currentSpringVol = Mathf.Pow(10, currentSpringVol / 20);
        currentForestVol = Mathf.Pow(10, currentForestVol / 20);
        currentSwampVol = Mathf.Pow(10, currentSwampVol / 20);
        currentPoolVol = Mathf.Pow(10, currentPoolVol / 20);
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentPoolVol, 1, currentTime /2);
            float newLow = Mathf.Lerp(currentForestVol, 0, currentTime / 2);
            ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("rockPoolVol", Mathf.Log10(newVol) * 20);
            ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
            Debug.Log("rockPool");
            yield return null;
        }
        yield break;
    }

    public IEnumerator SwampFade()
    {
        float currentTime = 0;
        ostMix.GetFloat("hotSpringVol", out currentSpringVol);
        ostMix.GetFloat("rainForestVol", out currentForestVol);
        ostMix.GetFloat("swampVol", out currentSwampVol);
        ostMix.GetFloat("rockPoolVol", out currentPoolVol);
        currentSpringVol = Mathf.Pow(10, currentSpringVol / 20);
        currentForestVol = Mathf.Pow(10, currentForestVol / 20);
        currentSwampVol = Mathf.Pow(10, currentSwampVol / 20);
        currentPoolVol = Mathf.Pow(10, currentPoolVol / 20);
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentSwampVol, 1, currentTime / 2);
            float newLow = Mathf.Lerp(currentSpringVol, 0.0001f, currentTime / 2);
            ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("swampVol", Mathf.Log10(newVol) * 20);
            ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
            Debug.Log("swampy");
            yield return null;
        }
        yield break;
    }

    public IEnumerator RainForestFade()
    {
        float currentTime = 0;
        ostMix.GetFloat("hotSpringVol", out currentSpringVol);
        ostMix.GetFloat("rainForestVol", out currentForestVol);
        ostMix.GetFloat("swampVol", out currentSwampVol);
        ostMix.GetFloat("rockPoolVol", out currentPoolVol);
        currentSpringVol = Mathf.Pow(10, currentSpringVol / 20);
        currentForestVol = Mathf.Pow(10, currentForestVol / 20);
        currentSwampVol = Mathf.Pow(10, currentSwampVol / 20);
        currentPoolVol = Mathf.Pow(10, currentPoolVol / 20);
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentForestVol, 1, currentTime / 2);
            float newLow = Mathf.Lerp(currentSpringVol, 0.0001f, currentTime / 2);
            ostMix.SetFloat("rainForestVol", Mathf.Log10(newVol) * 20);
            ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
            ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
            Debug.Log("rainforest");
            yield return null;
        }
        yield break;
    }
    #endregion


}
