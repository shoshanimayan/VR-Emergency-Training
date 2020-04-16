using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrill : MonoBehaviour
{
    public GameManager manager;
    public  bool running;
    public GameObject FireProps;
    public GameObject Door;
    private string instruction = "please follow the arrows to the exit";
    // Start is called before the first frame update
    void Awake()
    {
        running = false;
        FireProps.SetActive(false);
        Door.SetActive(true);
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
    public void message(string text)
    {
        manager.TextUpdate(text);
    }
    public void off()
    {
        FireProps.SetActive(false);
        Door.SetActive(true);
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
        UIMenu.AfterText = "Completed fire drill training\nTime: " + min + ":" + sec;
        manager.off();
    }

    public void Initiate()
    {
        manager.on();
        manager.TextUpdate(instruction);
        FireProps.SetActive(true);
        Door.SetActive(false);
        running = true;

    }
}
