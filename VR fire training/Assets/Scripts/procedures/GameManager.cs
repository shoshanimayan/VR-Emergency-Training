﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Timer;
    public Text Instructions;
    public bool running;
    public GameObject[] menus;
    public static float time;
    public musicManager music;
    // Start is called before the first frame update
    void Awake()
    {
        Timer.enabled = false;
        Instructions.enabled = false;
        running = false;
        
    }
    public void on() {
        time = 0;
        running = true;
        Timer.enabled = true;
        Instructions.enabled = true;
    }
    public void off() {
        music.Stop();
        Timer.enabled = false;
        Instructions.enabled = false;
        UIMenu.reset = true;
        running = false;
        foreach(GameObject menu in menus) { menu.SetActive(true); }
    }


    public void TextUpdate(string text) {
        Instructions.text = text;

    }
    // Update is called once per frame
    void Update()
    {
        if (running) {

            time += Time.deltaTime;
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
            Timer.text = "Time: " + min + ":" + sec;

        }
    }
}
