using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    private AudioSource AS;
    public AudioClip fireAlarm;
    public AudioClip EarthQuakeAlarm;
    
    // Start is called before the first frame update
    void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void FireDrill() {
        AS.clip = fireAlarm;
        AS.Play();
    }

    public void EarthQuakeDrill()
    {
        AS.clip = EarthQuakeAlarm;
        AS.Play();
    }

    public void Stop()
    {
        AS.Stop();
        
    }
}
