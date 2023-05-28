using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorbeltSFX : MonoBehaviour
{
    private DayCounter dayCounter;
    public AudioSource conveyorbelt;
    public float interval = 1f;
    private float nextMoveTime;
    public float timeLimit = 0f;
    public float nextDayDelay = 0f;

    private void Start()
    {
        dayCounter = GetComponent<DayCounter>();
        if (dayCounter.day >= 1)
        {
            nextMoveTime = Time.time + nextDayDelay;
        }
        else
        {
            nextMoveTime = Time.time + 1;
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