﻿using System;
using UnityEngine;
    /////////////////// 
    //private variables
    ///////////////////
    [SerializeField] private Text _timer;
    [SerializeField] private GameObject[] _menus;
    [SerializeField] private GameObject _instructionPanel;
    [SerializeField] private Text _info;
    [SerializeField] private GameObject _board;

    
    /////////////////// 
    //private methods
    //////////////////
    private void Awake()

    }

    private void ReadTime()
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
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
        _timer.text = "Time: " + min + ":" + sec;
    }
    private void Update()
        {
    private void CloseInstructions()
    {
        _instructionPanel.SetActive(false);
    }
    private void Close()
    {
        _board.SetActive(false);
    }


    /////////////////// 
    //public API
    //////////////////
    public musicManager music;
    public FireDrill fire;
    public EarthQuakeDrill earth;
    public string afterText;


        CloseInstructions();
        Close();
    {
         earth.Initiate();
    }

    public void StartFire()
    {
        fire.Initiate();
    }