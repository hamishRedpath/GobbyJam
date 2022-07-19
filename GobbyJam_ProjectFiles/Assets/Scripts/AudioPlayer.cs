using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource masterSource;

    [Header("Audio Clips")]
    public AudioClip hotSpring, rockPool, swampLand, rainForest;

    private float loopTimer;

    private void Start()
    {
        StartLoop();
    }

    private void Update()
    {
        if (loopTimer < hotSpring.length)
        {
            loopTimer += Time.deltaTime;
        }
        else
        {
            StartLoop();
        }
    }

    public void StartLoop()
    {
        masterSource.PlayOneShot(hotSpring);
        masterSource.PlayOneShot(rockPool);
        masterSource.PlayOneShot(swampLand);
        masterSource.PlayOneShot(rainForest);
        loopTimer = 0;
    }
}
