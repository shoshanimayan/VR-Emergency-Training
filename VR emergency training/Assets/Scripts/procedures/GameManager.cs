using System;using System.Collections;using System.Collections.Generic;using UnityEditor.VersionControl;
using UnityEngine;using UnityEngine.UI;public class GameManager : MonoBehaviour{
    /////////////////// 
    //private variables
    ///////////////////
    [SerializeField] private Text _timer;    [SerializeField] private Text _instructions;
    [SerializeField] private GameObject[] _menus;    private bool _running;

    /////////////////// 
    //private methods
    //////////////////
    private void Awake()    {        _timer.enabled = false;        _instructions.enabled = false;        _running = false;        hintsChecked = new List<GameObject>();

    }
    private void Update()    {        if (_running)
        {            time += Time.deltaTime;            float minutes = Mathf.Floor(time / 60);            float seconds = Mathf.RoundToInt(time % 60);            string min;            string sec;            if (minutes < 10)            {                min = "0" + minutes.ToString();            }            else { min = minutes.ToString(); }            if (seconds < 10)            {                sec = "0" + Mathf.RoundToInt(seconds).ToString();            }            else { sec = Mathf.RoundToInt(seconds).ToString(); }            _timer.text = "Time: " + min + ":" + sec;        }    }


    /////////////////// 
    //public API
    //////////////////
    public musicManager music;    public static float time;    public static List<GameObject> hintsChecked;    public static int hintsTotal;    public static bool Online;
    public FireDrill fire;
    public EarthQuakeDrill earth;
    public void On(int hints,string type) {        time = 0;        _running = true;        _timer.enabled = true;        _instructions.enabled = true;        hintsTotal = hints;        hintsChecked.Clear();    }    public void Off() {        music.StopAudio();        _timer.enabled = false;        _instructions.enabled = false;        UIMenu.reset = true;        _running = false;        foreach(GameObject menu in _menus) { menu.SetActive(true); }    }    public void TextUpdate(string text) {        _instructions.text = text;    }    public void StartEarthQuake()
    {
         earth.Initiate();

    }

    public void StartFire()
    {
        fire.Initiate();
    }}