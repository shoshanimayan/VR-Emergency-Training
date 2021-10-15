using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeDrill : Procedure
{
    /////////////////// 
    //private variables
    ///////////////////
    [SerializeField] private GameManager _manager;
    [SerializeField] private GameObject _earthQuakeProps;
    private string _instruction = "for your saftey get under a table during an earth quake";
    private NetworkManager _network { get { return NetworkManager.Instance; } }


    /////////////////// 
    //private methods
    //////////////////
    private void Awake()
    {
        running = false;
        _earthQuakeProps.SetActive(false);
    }

    /////////////////// 
    //public API
    //////////////////
    public bool running;
    public override void Off() 
    {
        _earthQuakeProps.SetActive(false);
        running = false;
        float t = GameManager.time;
        float minutes = Mathf.Floor(t / 60);
        float seconds = Mathf.RoundToInt(t % 60);
        string min;
        string sec;
        if (minutes < 10)
        {
            min = "0" + minutes.ToString();
        }
        else { min = minutes.ToString(); }
        if (seconds < 10)
        {
            sec = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else { sec = Mathf.RoundToInt(seconds).ToString(); }
        _manager.afterText = "Completed Earth Quake training\nTime: " + min + ":" + sec + "\nHints found: " + GameManager.hintsChecked.Count.ToString() + "/" + GameManager.hintsTotal.ToString();
        _manager.Off();
        if (GameManager.Online)
        {
            _network.SendExercise("earthQuake",GameManager.hintsTotal.ToString(),GameManager.hintsChecked.Count.ToString(),GameManager.time.ToString());
        }

    }

    public override void Initiate()
    {
        _manager.On(2,"earthquake");
        _manager.TextUpdate(_instruction);
        _earthQuakeProps.SetActive(true);
        running = true;
        _manager.music.EarthQuakeDrillAudio();


    }
}
