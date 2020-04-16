using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeDrill : MonoBehaviour
{
    public GameManager manager;
    public  bool running;
    public GameObject earthQuakeProps;
    private string instruction = "for your saftey get under a table during an earth quake";
    // Start is called before the first frame update
    void Awake()
    {
        running = false;
        earthQuakeProps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (running)
        {

        }
        else
        {
         
        }
    }
    public void message(string text) {
        manager.TextUpdate(text);
    }
    public void off() {
        manager.off();
        earthQuakeProps.SetActive(false);
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
        UIMenu.AfterText = "Completed earthquake training\nTime: "+ min + ":" + sec;
        ScreenShakeVR.active = false;

    }

    public void Initiate()
    {
        manager.on();
        manager.TextUpdate(instruction);
        earthQuakeProps.SetActive(true);
        running = true;
        ScreenShakeVR.active = true;
        manager.music.EarthQuakeDrill();


    }
}
