using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;



public class planeProcedure : MonoBehaviour
{
    public bool running;
    public Text Message;
    public  float time;
    public GameObject button1;
    public GameObject button2;
    public AudioSource AS;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject headNode;
    public GameObject pic1;
    public GameObject pic2;
    public AudioClip win;

    //device
    InputDevice handL;
    InputDevice handR ;
    InputDevice head;



    private string instruction = "For your safety, Please put your head in your lap with your hands ontop of your head";
    // Start is called before the first frame update
    void Awake()
    {

        handL = InputDevices.GetDeviceAtXRNode(leftHand.GetComponent<XRController>().controllerNode);
        handR = InputDevices.GetDeviceAtXRNode(rightHand.GetComponent<XRController>().controllerNode);
         head = InputDevices.GetDeviceAtXRNode(headNode.GetComponent<XRController>().controllerNode);

        pic1.SetActive(false);
        pic2.SetActive(false);

        running = false;
        AS.Pause();
        time = 0;
        Message.text = "Press Start to begin the Procedure";


    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            time += Time.deltaTime;
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
                off();
            }
        }
       
    }
    

    
    public void off()
    {
        running = false;
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
        Message.text = "Completed Plane Crash training\nTime: " + min + ":" + sec;
        button1.SetActive(true);
        button2.SetActive(true);
        pic1.SetActive(false);
        pic2.SetActive(false);
        AS.PlayOneShot(win);
        AS.Pause();
    }

    public void Initiate()
    {
        time = 0;
        running = true;
        AS.Play();
        button1.SetActive(false);
        button2.SetActive(false);
        Message.text = instruction;
        pic1.SetActive(true);
        pic2.SetActive(true);



    }
}
