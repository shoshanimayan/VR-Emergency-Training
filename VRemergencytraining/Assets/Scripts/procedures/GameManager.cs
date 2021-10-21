using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using TMPro;public class GameManager : MonoBehaviour{
    /////////////////// 
    //private variables
    ///////////////////
    [SerializeField] private TextMeshProUGUI _timer;    [SerializeField] private TextMeshProUGUI _instructions;
    [SerializeField] private GameObject[] _menus;
    [SerializeField] private GameObject _instructionPanel;
    [SerializeField] private TextMeshProUGUI _info;
    [SerializeField] private GameObject _board;
    private bool _running;
    
    /////////////////// 
    //private methods
    //////////////////
    private void Awake()    {        _timer.enabled = false;        _instructions.enabled = false;        _running = false;        hintsChecked = new List<GameObject>();
        _info.text = "";

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
    private void Update()    {        if (_running)
        {            time += Time.deltaTime;            ReadTime();        }    }
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
    public musicManager music;    public static float time;    public static List<GameObject> hintsChecked;    public static int hintsTotal;    public static bool Online;
    public FireDrill fire;
    public EarthQuakeDrill earth;
    public string afterText;

    public void On(int hints,string type) {
        CloseInstructions();
        Close();        time = 0;        _running = true;        _timer.enabled = true;        _instructions.enabled = true;        hintsTotal = hints;        hintsChecked.Clear();    }    public void Off() {        music.StopAudio();        _timer.enabled = false;        _instructions.enabled = false;        _running = false;        foreach(GameObject menu in _menus) { menu.SetActive(true); }        _info.text = afterText;     }    public void TextUpdate(string text)     {        _instructions.text = text;    }    public void StartEarthQuake()
    {
         earth.Initiate();
    }

    public void StartFire()
    {
        fire.Initiate();
    }}