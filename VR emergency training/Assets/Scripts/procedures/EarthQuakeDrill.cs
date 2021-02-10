using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeDrill : Procedure
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
        UIMenu.AfterText = "Completed Fire Drill training\nTime: " + min + ":" + sec + "\nHints found: " + GameManager.hintsChecked.Count.ToString() + "/" + GameManager.hintsTotal.ToString();

    }

    public override void Initiate()
    {
        manager.on(2,"earthquake");
        manager.TextUpdate(instruction);
        earthQuakeProps.SetActive(true);
        running = true;
        manager.music.EarthQuakeDrill();


    }
}
