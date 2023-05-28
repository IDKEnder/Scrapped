using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorbeltSFX : MonoBehaviour
{
    public DayCounter dayCounter;
    public AudioSource conveyorbelt;
    public float interval = 1f;
    private float nextMoveTime;
    public float timeLimit = 0f;

    private void Start()
    {
        nextMoveTime = Time.time + 1;
        if (dayCounter.day >= 1)
        {
            nextMoveTime = Time.time;
        }
    }

    private void Update()
    {
        if (Time.time >= nextMoveTime)
        {
            PlaySound();
            nextMoveTime = Time.time + interval;
        }
        if (Time.time >= timeLimit)
        {
            conveyorbelt.Pause();
        }
    }

    private void PlaySound()
    {
        conveyorbelt.Play();
    }
}