using System.Collections;using System.Collections.Generic;using UnityEngine;public class FireDrill : Procedure{
     
    //private variables
    
    [SerializeField] private GameManager _manager;    [SerializeField] private GameObject _fireProps;    [SerializeField] private GameObject _door;    private string _instruction = "please follow the arrows to evacuate the building";
    private NetworkManager _network { get { return NetworkManager.Instance; } }

     
    //private methods
    
    private void Awake()    {        running = false;        _fireProps.SetActive(false);        _door.SetActive(true);    }


     
    //public API
    
    public bool running;    public override void Off()    {        _fireProps.SetActive(false);        _door.SetActive(true);        running = false;        float t = GameManager.time;        float minutes = Mathf.Floor(t / 60);        float seconds = Mathf.RoundToInt(t % 60);        string min;        string sec;        if (minutes < 10)        {            min = "0" + minutes.ToString();        }        else { min = minutes.ToString(); }        if (seconds < 10)        {            sec = "0" + Mathf.RoundToInt(seconds).ToString();        }        else { sec = Mathf.RoundToInt(seconds).ToString(); }        _manager.afterText = "Completed Fire Drill training\nTime: " + min + ":" + sec + "\nHints found: " + GameManager.hintsChecked.Count.ToString() + "/" + GameManager.hintsTotal.ToString();        _manager.Off();
        if (GameManager.Online)
        {
            _network.SendExercise("earthQuake", GameManager.hintsTotal.ToString(), GameManager.hintsChecked.Count.ToString(), GameManager.time.ToString());
        }    }    public override void Initiate()    {        _manager.On(2,"Fire Drill");        _manager.TextUpdate(_instruction);        _fireProps.SetActive(true);        _door.SetActive(false);        running = true;        _manager.music.FireDrillAudio();    }}