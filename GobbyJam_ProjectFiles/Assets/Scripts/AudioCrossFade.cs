using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioCrossFade : MonoBehaviour
{
    public AudioMixer ostMix;

    public int trackNumber;
    public int previousTrack;

    public float currentVol;
    public float previousVol;

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

        switch (trackNumber)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out currentVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out currentVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out currentVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out currentVol);
                break;

        }

        switch (previousTrack)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out previousVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out previousVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out previousVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out previousVol);
                break;

        }

        previousVol = Mathf.Pow(10, previousVol / 20);
        currentVol = Mathf.Pow(10, currentVol / 20);

        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, 1, currentTime / 2);
            float newLow = Mathf.Lerp(previousVol, 0, currentTime / 2);

            switch (trackNumber)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newVol) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newVol) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newVol) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newVol) * 20);
                    break;

            }

            switch (previousTrack)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
                    break;

            }
            yield return null;
        }
        yield break;
    }

    public IEnumerator RockPoolFade()
    {
        float currentTime = 0;

        switch(trackNumber)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out currentVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out currentVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out currentVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out currentVol);
                break;

        }

        switch (previousTrack)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out previousVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out previousVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out previousVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out previousVol);
                break;

        }

        previousVol = Mathf.Pow(10, previousVol / 20);

        currentVol = Mathf.Pow(10, currentVol / 20);

        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, 1, currentTime /2);
            float newLow = Mathf.Lerp(previousVol, 0, currentTime / 2);

            switch (trackNumber)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newVol) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newVol) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newVol) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newVol) * 20);
                    break;

            }

            switch (previousTrack)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
                    break;

            }
            yield return null;
        }
        yield break;
    }

    public IEnumerator SwampFade()
    {
        float currentTime = 0;

        switch (trackNumber)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out currentVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out currentVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out currentVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out currentVol);
                break;

        }

        switch (previousTrack)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out previousVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out previousVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out previousVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out previousVol);
                break;

        }

        previousVol = Mathf.Pow(10, previousVol / 20);

        currentVol = Mathf.Pow(10, currentVol / 20);

        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, 1, currentTime / 2);
            float newLow = Mathf.Lerp(previousVol, 0, currentTime / 2);

            switch (trackNumber)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newVol) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newVol) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newVol) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newVol) * 20);
                    break;

            }

            switch (previousTrack)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
                    break;

            }
            yield return null;
        }
        yield break;
    }

    public IEnumerator RainForestFade()
    {
        float currentTime = 0;

        switch (trackNumber)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out currentVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out currentVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out currentVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out currentVol);
                break;

        }

        switch (previousTrack)
        {
            case 0:
                ostMix.GetFloat("hotSpringVol", out previousVol);
                break;
            case 1:
                ostMix.GetFloat("rainForestVol", out previousVol);
                break;
            case 2:
                ostMix.GetFloat("swampVol", out previousVol);
                break;
            case 3:
                ostMix.GetFloat("rockPoolVol", out previousVol);
                break;

        }

        previousVol = Mathf.Pow(10, previousVol / 20);

        currentVol = Mathf.Pow(10, currentVol / 20);

        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, 1, currentTime / 2);
            float newLow = Mathf.Lerp(previousVol, 0, currentTime / 2);

            switch (trackNumber)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newVol) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newVol) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newVol) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newVol) * 20);
                    break;

            }

            switch (previousTrack)
            {
                case 0:
                    ostMix.SetFloat("hotSpringVol", Mathf.Log10(newLow) * 20);
                    break;
                case 1:
                    ostMix.SetFloat("rainForestVol", Mathf.Log10(newLow) * 20);
                    break;
                case 2:
                    ostMix.SetFloat("swampVol", Mathf.Log10(newLow) * 20);
                    break;
                case 3:
                    ostMix.SetFloat("rockPoolVol", Mathf.Log10(newLow) * 20);
                    break;

            }
            yield return null;
        }
        yield break;
    }
    #endregion


}
