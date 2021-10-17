using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;



public class planeProcedure : Procedure
{
    /////////////////// 
    //private Variables
    ///////////////////
    private bool _running;
    private float _time;
    private string _instruction = "For your safety, Please put your head in your lap with your hands ontop of your head";

    [SerializeField] private Text _message;
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private AudioSource _aS;
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _headNode;
    [SerializeField] private GameObject _pic1;
    [SerializeField] private GameObject _pic2;
    [SerializeField] private AudioClip _win;

    private InputDevice handL;
    private InputDevice handR ;
    private InputDevice head;

    /////////////////// 
    //private methods
    //////////////////
    private void Awake()
    {

        handL = InputDevices.GetDeviceAtXRNode(_leftHand.GetComponent<XRController>().controllerNode);
        handR = InputDevices.GetDeviceAtXRNode(_rightHand.GetComponent<XRController>().controllerNode);
         head = InputDevices.GetDeviceAtXRNode(_headNode.GetComponent<XRController>().controllerNode);

        _pic1.SetActive(false);
        _pic2.SetActive(false);

        _running = false;
        _aS.Pause();
        _time = 0;
        _message.text = "Before beginning please make sure to be seated\nPress Start to begin the Procedure";


    }

    // Update is called once per frame
    private void Update()
    {
        if (_running)
        {
            _time += Time.deltaTime;
            Vector3 positionL = Vector3.zero;
            Vector3 positionR = Vector3.zero;
            Vector3 positionH = Vector3.zero;

            handL.TryGetFeatureValue(CommonUsages.devicePosition, out positionL);
            handR.TryGetFeatureValue(CommonUsages.devicePosition, out positionR);
            head.TryGetFeatureValue(CommonUsages.devicePosition, out positionH);
            Vector3 headToRight = (positionR - positionH);
            Vector3 headToLeft = (positionL - positionH);
            if (headToLeft.z <= 0 && headToRight.z <= 0)
            {
                Off();
            }
        }
       
    }

    /////////////////// 
    //public API
    //////////////////

    public override void Off()
    {
        _running = false;
        float minutes = Mathf.Floor(_time / 60);
        float seconds = Mathf.RoundToInt(_time % 60);
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
        _message.text = "Completed Plane Crash training\nTime: " + min + ":" + sec;
        _button1.SetActive(true);
        _button2.SetActive(true);
        _pic1.SetActive(false);
        _pic2.SetActive(false);
        _aS.PlayOneShot(_win);
        _aS.Pause();
    }

    public override void Initiate()
    {
        _time = 0;
        _running = true;
        _aS.Play();
        _button1.SetActive(false);
        _button2.SetActive(false);
        _message.text = _instruction;
        _pic1.SetActive(true);
        _pic2.SetActive(true);



    }
}
