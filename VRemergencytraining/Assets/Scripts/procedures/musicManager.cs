using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    /////////////////// 
    //private Variables
    ///////////////////
    private AudioSource _aS;
    [SerializeField] private AudioClip _fireAlarm;
    [SerializeField] private AudioClip _EarthQuakeAlarm;


    /////////////////// 
    //private methods
    //////////////////
    private void Awake()
    {
        _aS = GetComponent<AudioSource>();
    }

    /////////////////// 
    //public API
    //////////////////
    public void FireDrillAudio() {
        _aS.clip = _fireAlarm;
        _aS.Play();
    }

    public void EarthQuakeDrillAudio()
    {
        _aS.clip = _EarthQuakeAlarm;
        _aS.Play();
    }

    public void StopAudio()
    {
        _aS.Stop();
        
    }
}
