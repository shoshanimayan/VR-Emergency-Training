using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMenu : MonoBehaviour
{
    /////////////////// 
    //private variables
    ///////////////////
    [SerializeField] private GameObject _instructions;
    [SerializeField] private Text _info;
    [SerializeField] private GameManager _manager;

    private GameObject _board;

    /////////////////// 
    //private methods
    ///////////////////
    private void Awake()
    {
        _board = transform.parent.gameObject;
        if (reset) {
            _info.text = afterText;
            reset = false;
        }

    }

    private void Update() {

        if (reset)
        {
            _info.text = afterText;
            reset = false;
        }
    }

    private void CloseInstructions()
    {

        _instructions.SetActive(false);
    }
    private void Close()
    {
        _board.SetActive(false);
    }

    /////////////////// 
    //public API
    //////////////////
    public static string afterText;
    public static bool reset = false;

 

    public void StartFire()
    {
        CloseInstructions();
        _manager.StartFire();
        Close();
    }
    public void StartEarth()
    {
        CloseInstructions();
        _manager.StartEarthQuake();
        Close();
    }

}
